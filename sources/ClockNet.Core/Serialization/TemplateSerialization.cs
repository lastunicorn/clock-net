// ClockNet
// Copyright (C) 2010 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using DustInTheWind.ClockNet.Core.Shapes;

namespace DustInTheWind.ClockNet.Core.Serialization
{
    /// <summary>
    /// Provides methods to serialize and deserialize a <see cref="TemplateBase"/> to and from a stream.
    /// Shape types are identified by the GUID specified in their <see cref="ShapeAttribute"/>.
    /// </summary>
    public class TemplateSerialization
    {
        private const string BackgroundsElementName = "Backgrounds";
        private const string RimMarkersElementName = "RimMarkers";
        private const string HandsElementName = "Hands";

        private readonly Dictionary<Guid, Type> shapeTypesByGuid = new Dictionary<Guid, Type>();
        private readonly Dictionary<Type, Guid> guidsByShapeType = new Dictionary<Type, Guid>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateSerialization"/> class.
        /// Discovers all shape types with <see cref="ShapeAttribute"/> in the current assembly.
        /// </summary>
        public TemplateSerialization()
        {
            IEnumerable<Type> shapeTypes = AppDomain.CurrentDomain.GetTypesImplementing<IShape>();

            foreach (Type type in shapeTypes)
            {
                ShapeAttribute attribute = type.GetCustomAttribute<ShapeAttribute>();

                if (attribute != null)
                {
                    shapeTypesByGuid[attribute.Id] = type;
                    guidsByShapeType[type] = attribute.Id;
                }
            }
        }

        /// <summary>
        /// Serializes the specified <see cref="TemplateBase"/> to the given stream.
        /// </summary>
        /// <param name="template">The template to serialize.</param>
        /// <param name="stream">The stream to write the serialized data to.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="template"/> or <paramref name="stream"/> is null.</exception>
        public void Serialize(TemplateBase template, Stream stream)
        {
            if (template == null)
                throw new ArgumentNullException(nameof(template));

            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = Encoding.UTF8
            };

            using (XmlWriter writer = XmlWriter.Create(stream, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("ClockTemplate");

                WriteShapeArray(writer, BackgroundsElementName, template.Backgrounds);
                WriteShapeArray(writer, RimMarkersElementName, template.RimMarkers);
                WriteShapeArray(writer, HandsElementName, template.Hands);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        /// <summary>
        /// Serializes the specified <see cref="TemplateBase"/> to an XML string.
        /// </summary>
        /// <param name="template">The template to serialize.</param>
        /// <returns>An XML string representation of the template.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="template"/> is null.</exception>
        public string SerializeToString(TemplateBase template)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Serialize(template, stream);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        /// <summary>
        /// Deserializes a <see cref="TemplateBase"/> from the given stream.
        /// </summary>
        /// <param name="stream">The stream containing the serialized template data.</param>
        /// <returns>The deserialized <see cref="TemplateBase"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stream"/> is null.</exception>
        public TemplateBase Deserialize(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            XmlDocument doc = new XmlDocument();
            doc.Load(stream);

            Template template = new Template();

            XmlNode backgroundNode = doc.SelectSingleNode("/ClockTemplate/" + BackgroundsElementName);
            if (backgroundNode != null)
            {
                IBackground[] backgrounds = ReadShapes<IBackground>(backgroundNode);
                template.Backgrounds.AddRange(backgrounds);
            }

            XmlNode rimMarkerNode = doc.SelectSingleNode("/ClockTemplate/" + RimMarkersElementName);
            if (rimMarkerNode != null)
            {
                IRimMarker[] rimMarkers = ReadShapes<IRimMarker>(rimMarkerNode);
                template.RimMarkers.AddRange(rimMarkers);
            }

            XmlNode handNode = doc.SelectSingleNode("/ClockTemplate/" + HandsElementName);
            if (handNode != null)
            {
                IHand[] hands = ReadShapes<IHand>(handNode);
                template.Hands.AddRange(hands);
            }

            return template;
        }

        /// <summary>
        /// Deserializes a <see cref="TemplateBase"/> from the given XML string.
        /// </summary>
        /// <param name="xml">The XML string containing the serialized template data.</param>
        /// <returns>The deserialized <see cref="TemplateBase"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="xml"/> is null.</exception>
        public TemplateBase DeserializeFromString(string xml)
        {
            if (xml == null)
                throw new ArgumentNullException(nameof(xml));

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                return Deserialize(stream);
            }
        }

        private void WriteShapeArray<T>(XmlWriter writer, string elementName, IReadOnlyList<T> shapes)
            where T : IShape
        {
            if (shapes == null)
                return;

            writer.WriteStartElement(elementName);

            foreach (T shape in shapes)
                WriteShape(writer, shape);

            writer.WriteEndElement();
        }

        private void WriteShape(XmlWriter writer, IShape shape)
        {
            if (shape == null)
                return;

            Type shapeType = shape.GetType();

            if (!guidsByShapeType.TryGetValue(shapeType, out Guid shapeGuid))
            {
                throw new InvalidOperationException($"Shape type '{shapeType.FullName}' does not have a {nameof(ShapeAttribute)}.");
            }

            writer.WriteStartElement("Shape");
            writer.WriteAttributeString("TypeId", shapeGuid.ToString());

            if (shape is ISerializable serializableShape)
            {
                WriteShapePropertiesFromSerializable(writer, serializableShape);
            }

            writer.WriteEndElement();
        }

        private void WriteShapePropertiesFromSerializable(XmlWriter writer, ISerializable serializableShape)
        {
            Dictionary<string, string> properties = serializableShape.Serialize();

            foreach (KeyValuePair<string, string> kvp in properties)
            {
                writer.WriteStartElement("Property");
                writer.WriteAttributeString("Name", kvp.Key);
                writer.WriteAttributeString("Value", kvp.Value);
                writer.WriteEndElement();
            }
        }

        private T[] ReadShapes<T>(XmlNode parentNode) where T : IShape
        {
            List<T> shapes = new List<T>();

            foreach (XmlNode shapeNode in parentNode.SelectNodes("Shape"))
            {
                T shape = ReadShape<T>(shapeNode);

                if (shape != null)
                    shapes.Add(shape);
            }

            return shapes.ToArray();
        }

        private T ReadShape<T>(XmlNode shapeNode) where T : IShape
        {
            XmlAttribute typeIdAttr = shapeNode.Attributes["TypeId"];
            if (typeIdAttr == null)
                return default;

            if (!Guid.TryParse(typeIdAttr.Value, out Guid typeId))
            {
                string message = string.Format("Invalid shape type ID: '{0}'.", typeIdAttr.Value);
                throw new InvalidOperationException(message);
            }

            if (!shapeTypesByGuid.TryGetValue(typeId, out Type shapeType))
            {
                string message = string.Format("Unknown shape type ID: '{0}'. Make sure the shape type is registered.", typeId);
                throw new InvalidOperationException(message);
            }

            IShape shape = (IShape)Activator.CreateInstance(shapeType);

            if (shape is ISerializable serializableShape)
            {
                Dictionary<string, string> properties = ReadPropertiesFromNode(shapeNode);
                serializableShape.Deserialize(properties);
            }

            return (T)shape;
        }

        private Dictionary<string, string> ReadPropertiesFromNode(XmlNode shapeNode)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();

            foreach (XmlNode propertyNode in shapeNode.SelectNodes("Property"))
            {
                XmlAttribute nameAttr = propertyNode.Attributes["Name"];
                if (nameAttr == null)
                    continue;

                XmlAttribute valueAttr = propertyNode.Attributes["Value"];
                if (valueAttr == null)
                    continue;

                string propertyName = nameAttr.Value;
                string serializedValue = valueAttr.Value;

                properties[propertyName] = serializedValue;
            }

            return properties;
        }
    }
}
