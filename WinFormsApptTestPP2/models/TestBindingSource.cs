using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApptTestPP2.models
{
    /// <summary>
    /// Solucion encontrada en StackOverFlow
    /// 
    /// Basicamente hace que el Binding Source se actualice 
    /// debido a que esta no es posible actualizarla con los metodos Ivoke
    /// 
    /// </summary>
 
    public class SyncBindingSource : BindingSource
    {
        private SynchronizationContext syncContext;
        public SyncBindingSource()
        {
            syncContext = SynchronizationContext.Current;
        }
        /*
         protected override void OnListChanged(ListChangedEventArgs e)
         {
             try
             {
                 if (syncContext != null)
                     syncContext.Send(_ => base.OnListChanged(e), null);
                 else
                     base.OnListChanged(e);
             }
             catch (Exception ex)
             {
                 return;
             }
         }
         */
    }
}
