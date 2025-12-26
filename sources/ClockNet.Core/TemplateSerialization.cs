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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using DustInTheWind.ClockNet.Shapes;

namespace DustInTheWind.ClockNet
{
    /// <summary>
    /// Provides methods to serialize and deserialize a <see cref="ClockTemplate"/> to and from a stream.
    /// Shape types are identified by the GUID specified in their <see cref="ShapeAttribute"/>.
    /// </summary>
    public class TemplateSerialization
    {
        private readonly Dictionary<Guid, Type> shapeTypesByGuid;
        private readonly Dictionary<Type, Guid> guidsByShapeType;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateSerialization"/> class.
        /// Discovers all shape types with <see cref="ShapeAttribute"/> in the current assembly.
        /// </summary>
        public TemplateSerialization()
            : this(typeof(IShape).Assembly)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateSerialization"/> class.
        /// Discovers all shape types with <see cref="ShapeAttribute"/> in the specified assemblies.
        /// </summary>
        /// <param name="assemblies">The assemblies to scan for shape types.</param>
        public TemplateSerialization(params Assembly[] assemblies)
        {
            if (assemblies == null)
                throw new ArgumentNullException(nameof(assemblies));

            shapeTypesByGuid = new Dictionary<Guid, Type>();
            guidsByShapeType = new Dictionary<Type, Guid>();

            foreach (Assembly assembly in assemblies)
                DiscoverShapeTypes(assembly);
        }

        private void DiscoverShapeTypes(Assembly assembly)
        {
            IEnumerable<Type> shapeTypes = assembly.GetTypes()
                .Where(x => !x.IsAbstract && typeof(IShape).IsAssignableFrom(x));

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
        /// Serializes the specified <see cref="ClockTemplate"/> to the given stream.
        /// </summary>
        /// <param name="template">The template to serialize.</param>
        /// <param name="stream">The stream to write the serialized data to.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="template"/> or <paramref name="stream"/> is null.</exception>
        public void Serialize(ClockTemplate template, Stream stream)
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

                WriteShapeArray(writer, "BackgroundShapes", template.BackgroundShapes);
                WriteShapeArray(writer, "AngularShapes", template.AngularShapes);
                WriteShapeArray(writer, "HandShapes", template.HandShapes);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        /// <summary>
        /// Serializes the specified <see cref="ClockTemplate"/> to an XML string.
        /// </summary>
        /// <param name="template">The template to serialize.</param>
        /// <returns>An XML string representation of the template.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="template"/> is null.</exception>
        public string SerializeToString(ClockTemplate template)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Serialize(template, stream);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        /// <summary>
        /// Deserializes a <see cref="ClockTemplate"/> from the given stream.
        /// </summary>
        /// <param name="stream">The stream containing the serialized template data.</param>
        /// <returns>The deserialized <see cref="ClockTemplate"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stream"/> is null.</exception>
        public ClockTemplate Deserialize(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            XmlDocument doc = new XmlDocument();
            doc.Load(stream);

            ClockTemplate template = new ClockTemplate();

            XmlNode backgroundNode = doc.SelectSingleNode("/ClockTemplate/BackgroundShapes");
            if (backgroundNode != null)
            {
                template.BackgroundShapes = ReadShapes<IBackground>(backgroundNode);
            }

            XmlNode angularNode = doc.SelectSingleNode("/ClockTemplate/AngularShapes");
            if (angularNode != null)
            {
                template.AngularShapes = ReadShapes<IRimMarker>(angularNode);
            }

            XmlNode handNode = doc.SelectSingleNode("/ClockTemplate/HandShapes");
            if (handNode != null)
            {
                template.HandShapes = ReadShapes<IHand>(handNode);
            }

            return template;
        }

        /// <summary>
        /// Deserializes a <see cref="ClockTemplate"/> from the given XML string.
        /// </summary>
        /// <param name="xml">The XML string containing the serialized template data.</param>
        /// <returns>The deserialized <see cref="ClockTemplate"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="xml"/> is null.</exception>
        public ClockTemplate DeserializeFromString(string xml)
        {
            if (xml == null)
                throw new ArgumentNullException(nameof(xml));

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                return Deserialize(stream);
            }
        }

        private void WriteShapeArray<T>(XmlWriter writer, string elementName, T[] shapes)
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

            WriteShapeProperties(writer, shape);

            writer.WriteEndElement();
        }

        private void WriteShapeProperties(XmlWriter writer, IShape shape)
        {
            Type shapeType = shape.GetType();
            PropertyInfo[] propertyInfos = shapeType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (!propertyInfo.CanRead || !propertyInfo.CanWrite)
                    continue;

                if (ShouldSkipProperty(propertyInfo))
                    continue;

                object value = propertyInfo.GetValue(shape);

                if (value != null)
                {
                    string serializedValue = ConvertToSerializableValue(value);
                    if (serializedValue != null)
                    {
                        writer.WriteStartElement("Property");
                        writer.WriteAttributeString("Name", propertyInfo.Name);
                        writer.WriteAttributeString("Type", propertyInfo.PropertyType.FullName);
                        writer.WriteString(serializedValue);
                        writer.WriteEndElement();
                    }
                }
            }
        }

        private bool ShouldSkipProperty(PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType == typeof(EventHandler))
                return true;

            string[] skipPropertyNames = { "Changed", "Disposed" };
            if (skipPropertyNames.Contains(propertyInfo.Name))
                return true;

            Type propertyType = propertyInfo.PropertyType;
            if (propertyType == typeof(Brush) ||
                propertyType == typeof(Pen) ||
                propertyType == typeof(Graphics) ||
                propertyType == typeof(GraphicsPath))
                return true;

            return false;
        }

        private string ConvertToSerializableValue(object value)
        {
            if (value == null)
                return null;

            Type valueType = value.GetType();

            if (valueType.IsPrimitive || valueType == typeof(string) || valueType == typeof(decimal))
                return value.ToString();

            if (valueType.IsEnum)
                return value.ToString();

            if (valueType == typeof(TimeSpan))
                return ((TimeSpan)value).ToString();

            if (valueType == typeof(Color))
            {
                Color color = (Color)value;
                return color.IsNamedColor ? color.Name : color.ToArgb().ToString();
            }

            if (valueType == typeof(PointF))
            {
                PointF point = (PointF)value;
                return string.Format("{0},{1}", point.X, point.Y);
            }

            if (valueType == typeof(SizeF))
            {
                SizeF size = (SizeF)value;
                return string.Format("{0},{1}", size.Width, size.Height);
            }

            if (valueType == typeof(RectangleF))
            {
                RectangleF rect = (RectangleF)value;
                return string.Format("{0},{1},{2},{3}", rect.X, rect.Y, rect.Width, rect.Height);
            }

            if (valueType == typeof(Font))
            {
                Font font = (Font)value;
                return string.Format("{0},{1},{2}", font.FontFamily.Name, font.Size, font.Style);
            }

            if (valueType == typeof(PointF[]))
            {
                PointF[] points = (PointF[])value;
                return string.Join(";", points.Select(p => string.Format("{0},{1}", p.X, p.Y)));
            }

            return value.ToString();
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
            ReadShapeProperties(shape, shapeNode);

            return (T)shape;
        }

        private void ReadShapeProperties(IShape shape, XmlNode shapeNode)
        {
            Type shapeType = shape.GetType();

            foreach (XmlNode propertyNode in shapeNode.SelectNodes("Property"))
            {
                XmlAttribute nameAttr = propertyNode.Attributes["Name"];
                if (nameAttr == null)
                    continue;

                string propertyName = nameAttr.Value;
                string serializedValue = propertyNode.InnerText;

                PropertyInfo propertyInfo = shapeType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo == null || !propertyInfo.CanWrite)
                    continue;

                try
                {
                    object value = ConvertFromSerializedValue(serializedValue, propertyInfo.PropertyType);
                    propertyInfo.SetValue(shape, value);
                }
                catch
                {
                    // Skip properties that fail to deserialize
                }
            }
        }

        private object ConvertFromSerializedValue(string serializedValue, Type targetType)
        {
            if (serializedValue == null)
                return null;

            if (targetType == typeof(bool))
                return bool.Parse(serializedValue);

            if (targetType == typeof(int))
                return int.Parse(serializedValue);

            if (targetType == typeof(float))
                return float.Parse(serializedValue);

            if (targetType == typeof(double))
                return double.Parse(serializedValue);

            if (targetType == typeof(decimal))
                return decimal.Parse(serializedValue);

            if (targetType == typeof(string))
                return serializedValue;

            if (targetType.IsEnum)
                return Enum.Parse(targetType, serializedValue);

            if (targetType == typeof(TimeSpan))
                return TimeSpan.Parse(serializedValue);

            if (targetType == typeof(Color))
            {
                if (int.TryParse(serializedValue, out int argb))
                    return Color.FromArgb(argb);
                
                return Color.FromName(serializedValue);
            }

            if (targetType == typeof(PointF))
            {
                string[] parts = serializedValue.Split(',');
                
                float x = float.Parse(parts[0]);
                float y = float.Parse(parts[1]);
                
                return new PointF(x, y);
            }

            if (targetType == typeof(SizeF))
            {
                string[] parts = serializedValue.Split(',');
                
                float width = float.Parse(parts[0]);
                float height = float.Parse(parts[1]);

                return new SizeF(width, height);
            }

            if (targetType == typeof(RectangleF))
            {
                string[] parts = serializedValue.Split(',');
                return new RectangleF(
                    float.Parse(parts[0]),
                    float.Parse(parts[1]),
                    float.Parse(parts[2]),
                    float.Parse(parts[3]));
            }

            if (targetType == typeof(Font))
            {
                string[] parts = serializedValue.Split(',');
                string fontFamily = parts[0];
                float size = float.Parse(parts[1]);
                FontStyle style = (FontStyle)Enum.Parse(typeof(FontStyle), parts[2]);
                return new Font(fontFamily, size, style);
            }

            if (targetType == typeof(PointF[]))
            {
                if (string.IsNullOrEmpty(serializedValue))
                    return new PointF[0];

                string[] pointStrings = serializedValue.Split(';');
                return pointStrings
                    .Select(x =>
                    {
                        string[] parts = x.Split(',');
                        return new PointF(float.Parse(parts[0]), float.Parse(parts[1]));
                    })
                    .ToArray();
            }

            return serializedValue;
        }
    }
}
