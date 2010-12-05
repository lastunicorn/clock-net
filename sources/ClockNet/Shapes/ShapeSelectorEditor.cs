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
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms.Design;

namespace DustInTheWind.Clock.Shapes
{
    public class ShapeSelectorEditor : ObjectSelectorEditor
    {
        //public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        //{
        //    return UITypeEditorEditStyle.Modal;
        //    //return base.GetEditStyle(context);
        //}

        //public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        //{
        //    IWindowsFormsEditorService frmsvr = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
        //    //frmsvr.DropDownControl(tbr); //tbr = Object of Type track bar
        //    frmsvr.ShowDialog(new Form1());

        //    return value;
        //    return base.EditValue(context, provider, value);
        //}

        protected override void FillTreeWithData(ObjectSelectorEditor.Selector selector, ITypeDescriptorContext context, IServiceProvider provider)
        {
            base.FillTreeWithData(selector, context, provider);
            //base.FillTreeWithData(theSel, theCtx, theProvider);  //clear the selection

            MultiPaneControl aCtl = (MultiPaneControl)theCtx.Instance;

            foreach (MultiPanePage aIt in aCtl.Controls)
            {
                SelectorNode aNd = new SelectorNode(aIt.Name, aIt);

                selector.Nodes.Add(aNd);

                if (aIt == aCtl.SelectedPage)
                    selector.SelectedNode = aNd;
            }

        }
    }
}
