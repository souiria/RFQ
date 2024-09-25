using Infragistics.Controls.Editors;
using System;

namespace SEWSE.H1.UX.Infrastructure.Core.Helpers
{
    public class PreviewKeyDownHelper : IDisposable
    {
        public PreviewKeyDownHelper()
        {

        }

        public void PreviewKeyDownHandler(ref object sender, ref System.Windows.Input.KeyEventArgs e, ref System.Windows.Input.Key previousKey)
        {

            XamMultiColumnComboEditor editor = sender as XamMultiColumnComboEditor;
            
            //  Handle Tab key down.
            if (e.Key == System.Windows.Input.Key.Back || e.Key == System.Windows.Input.Key.Delete)
                editor.SelectedItem = null;
            else if (previousKey != System.Windows.Input.Key.Delete && previousKey != System.Windows.Input.Key.Back)
            {
                if (e.Key == System.Windows.Input.Key.Tab)
                {
                    //  Find which item the user has focused.
                    foreach (ComboRow row in editor.Items)
                    {
                        if (row.IsFocused)
                        {
                            editor.SelectedItem = row.Data;
                            break;
                        }
                    }
                }
            }
            //else if (previousKey != System.Windows.Input.Key.Delete && previousKey != System.Windows.Input.Key.Back && editor.IsDropDownOpen == false && mouseLeftButtonPressed == true)
            //{
            //    if (e.Key == System.Windows.Input.Key.Tab)
            //    {
            //        //  Find which item the user has focused.
            //        foreach (ComboRow row in editor.Items)
            //        {
            //            if (row.IsFocused)
            //            {
            //                editor.SelectedItem = row.Data;
            //                break;
            //            }
            //        }
            //    }
            //}
            else if ((previousKey == System.Windows.Input.Key.Back || previousKey == System.Windows.Input.Key.Delete) && e.Key == System.Windows.Input.Key.Tab)
                editor.SelectedItem = null;
            else
                editor.SelectedItem = null;

            previousKey = e.Key;
            //mouseLeftButtonPressed = false;
        }

        #region

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
           
         
        }
        ~PreviewKeyDownHelper()
        {
    
            // The object went out of scope and finalized is called
            // Lets call dispose in to release unmanaged resources 
            // the managed resources will anyways be released when GC 
            // runs the next time.
            Dispose(false);
        }

        #endregion
    }
}
