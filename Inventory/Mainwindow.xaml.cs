using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;
using static System.Reflection.BindingFlags;
using System.ComponentModel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Controls.Primitives;
using DataGridFilterLibrary.Querying;

namespace Inventory
{
    /// <summary>
    /// Interaction logic for Mainwindow.xaml
    /// </summary>
    /// 


  

    public class InventoryItem 
    {

        [DGDisplayAttribute_History("Equipment Type")]
        [DGDisplay("Equipment Type")]
        public string Equipment_Type { get; set; }



        [DGDisplayAttribute_History("Serial Number")]
        [DGDisplay("Serial Number")]
        public string Serial_Number { get; set; }

   
     
        [DGDisplayAttribute_History("Make")]
        [DGDisplay("Make")]
        public string Make { get; set; }

       
        [DGDisplayAttribute_History("Model")]
        [DGDisplay("Model")]
        public string Model { get; set; }

        [DGDisplayAttribute_History("Deployed To")]
        [DGDisplay("Deployed To")]
        public string Deployed_To { get; set; }

      
        [DGDisplayAttribute_History("Machine Name")]
        [DGDisplay("Machine Name")]
        public string Machine_Name { get; set; }

        [DGDisplayAttribute_History("Conway Tag")]
        [DGDisplay("Conway Tag")]
        public string Conway_Tag { get; set; }

     
        [DGDisplayAttribute_History("Status")]
        [DGDisplay("Status")]
        public string Status { get; set; }

        [DGDisplayAttribute_History("Notes")]
        [DGDisplay("Notes")]
        public string Notes { get; set; }

        [DGDisplayAttribute_History("Field Equipment")]
        [DGDisplay("Field Equipment")]
        public string Field_Equipment { get; set; }

        [DGDisplayAttribute_History("Create User")]
        [DGDisplay("Create User")]
        public string Create_User { get; set; }

        [DGDisplayAttribute_History("Create Date")]
        [DGDisplay("Create Date")]
        public DateTime Create_Date { get; set; }














        public InventoryItem() { }
    }
    public class FieldItem
    {
     
        [DGDisplayAttribute_Field("Office Location")]
        public string Office { get; set; }

        [DGDisplayAttribute_Field("Serial Number")]
        public string Serial_Number { get; set; }

        [DGDisplayAttribute_Field("Make")]
        public string Make { get; set; }

        [DGDisplayAttribute_Field("Model")]
        public string Model { get; set; }

        [DGDisplayAttribute_Field("Deployed To")]
        public string Deployed_To { get; set; }

        [DGDisplayAttribute_Field("Machine Name")]
        public string Machine_Name { get; set; }

        [DGDisplayAttribute_Field("Status")]
        public string Status { get; set; }

        [DGDisplayAttribute_Field("Notes")]
        public string Notes { get; set; }

        [DGDisplayAttribute_Field("Docking Stations")]
        public int Dock_Count { get; set; }

        [DGDisplayAttribute_Field("Mouse Count")]
        public int Mouse_Count { get; set; }

        [DGDisplayAttribute_Field("Monitor Count")]
        public int Monitor_Count { get; set; }

        [DGDisplayAttribute_Field("Keyboard Count")]
        public int Key_Count { get; set; }

        [DGDisplayAttribute_Field("Printer")]
        public string Printer { get; set; }

        [DGDisplayAttribute_Field("Create User")]
        public string Create_User { get; set; }

        [DGDisplayAttribute_Field("Create Date")]
        public DateTime Create_Date { get; set; }

        public string Equipment_Type { get; set; }

        public string Conway_Tag { get; set; }



        public FieldItem() { }
    }



    //public InventoryItem(object anonymousObject)
    //{
    //    //get the type of the argument
    //    var anonType = anonymousObject.GetType();

    //    //make sure it's an anonymous type
    //    if (anonType.Namespace != null) return;

    //    //loop through every public property and try to match it to the anonymous type
    //    foreach (var prop in GetType().GetProperties(Public | Instance))
    //    {
    //        //see if the anonymous type has a matching property (null does not pattern match)
    //        if (anonType.GetProperty(prop.Name) is PropertyInfo anonProp)
    //        {
    //            //if we found matching properties, set the value! This will fail if there are
    //            //properties with matching names that have different types.
    //            prop.SetValue(this, anonProp.GetValue(anonymousObject));
    //        }
    //    }
    //}
    // }


    public class DGDisplayAttribute : Attribute
    {
        public string HeaderName { get; set; }
        public DGDisplayAttribute(string header = null) => HeaderName = header;
    }
    public class DGDisplayAttribute_Field : Attribute
    {
        public string HeaderName { get; set; }
        public DGDisplayAttribute_Field(string header = null) => HeaderName = header;
    }
    public class DGDisplayAttribute_History : Attribute
    {
        public string HeaderName { get; set; }
        public DGDisplayAttribute_History(string header = null) => HeaderName = header;
    }




    public partial class Mainwindow : Window
    {

        private BackgroundWorker bwexport = new BackgroundWorker();

        public DataTable export_table;
   

        public Mainwindow()
        {
       

            InitializeComponent();
            bwexport.WorkerReportsProgress = true;
            bwexport.WorkerSupportsCancellation = true;
            bwexport.DoWork += new DoWorkEventHandler(bwexport_DoWork);
            bwexport.ProgressChanged += new ProgressChangedEventHandler(bwexport_ProgressChanged);
            bwexport.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwexport_RunWorkerCompleted);


            try
            {

              

                summary();



                DataContext = null;

                dg_inventory.Visibility = Visibility.Visible;
                dg_history.Visibility = Visibility.Collapsed;
                dg_field_equipment.Visibility = Visibility.Collapsed;
             
            

                //select from Equipment class and put into InventoryItem class so on updatedatabase doesnt wipe out datagrid selections.
                
                var context = new EquipmentEntities();
                var query1 = (from a in context.Equipments
                             select new InventoryItem
                             {

                                 Serial_Number = a.Serial_Number,
                                 Make = a.Make,
                                 Model = a.Model,
                                 Deployed_To = a.Deployed_To,
                                 Machine_Name = a.Machine_Name,
                                 Equipment_Type = a.Eq_Type,
                                 Conway_Tag = a.Conway_Tag,
                                 Status = a.Status,
                                 Notes = a.Notes,
                                 Field_Equipment = a.Field,
                                 Create_User = a.Create_User,
                                 Create_Date = a.Create_Date ?? DateTime.MinValue
                             }).ToList();

                DataContext = query1;
                




            }

            catch (System.Data.Entity.Core.EntityException)
            {
                MessageBox.Show("Error, there is an issue with remote server. Please contact IT.", "Error");


            }

        }


        // background workers;

        private void bwexport_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable export = null;

            var cat = "";
            var field = "";
            var history = "";


            //dg_inventory.Dispatcher.Invoke(new Action(delegate () { cat = dg_inventory.ItemsSource; }));
            //if (cat != 0) { export = Mainwindow.CreateDataTable(dg_inventory.ItemsSource); }

            //cbx_field.Dispatcher.Invoke(new Action(delegate () { field = cbx_field.SelectedIndex; }));
            //if (field != 0) { export = Mainwindow.CreateDataTable(dg_field_equipment.ItemsSource); }

            //cbx_employee_history.Dispatcher.Invoke(new Action(delegate () { history = cbx_employee_history.SelectedIndex; }));
            //if (history != 0) { export = Mainwindow.CreateDataTable(dg_history.ItemsSource); }


            //Microsoft.Office.Interop.Excel.Application excel;
            //Microsoft.Office.Interop.Excel.Workbook workBook;
            //Microsoft.Office.Interop.Excel.Worksheet workSheet;
            //Microsoft.Office.Interop.Excel.Range cellRange;


            try
            {

                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = false;
                Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
                Microsoft.Office.Interop.Excel.Range cellRange;


               // app = new Microsoft.Office.Interop.Excel.Application();
                app.DisplayAlerts = false;
              //  app.Visible = false;
              //  wb = app.Workbooks.Add(Type.Missing);
               // ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;
              //  ws.Name = "Invenotry Export";


                // System.Data.DataTable tempDt = DtIN;
                // dgExcel.ItemsSource = tempDt.DefaultView;
                ws.Cells.Font.Size = 11;
                int rowcount = 1;
                for (int i = 1; i <= export.Columns.Count; i++) //taking care of Headers.  
                {
                    ws.Cells[1, i] = export.Columns[i - 1].ColumnName;
                }
                foreach (System.Data.DataRow row in export.Rows) //taking care of each Row  
                {
                    rowcount += 1;
                    for (int i = 0; i < export.Columns.Count; i++) //taking care of each column  
                    {
                        ws.Cells[rowcount, i + 1] = row[i].ToString();
                    }
                }
                cellRange = ws.Range[ws.Cells[1, 1], ws.Cells[rowcount, export.Columns.Count]];
                cellRange.EntireColumn.AutoFit();


                string str = @"\Inventory";
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                wb.SaveAs(path + str);
                wb.Close();
                app.Quit();

                MessageBox.Show("Invenotry has been exported to desktop.", "Completed!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ," + ex.Message,"Error");
            }

        }
        private void bwexport_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {



        }
        private void bwexport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                //this.txtLoad.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                MessageBox.Show("System Error", "Error");
            }

            else
            {
               
                media_load.Visibility = Visibility.Hidden;
              



              }

            

            }

        

        //GetfileName
        private string getFileName(string path)
        {
            return System.IO.Path.GetFileName(path);
        }

        //GetfileNameandpath
        private string getFileNameandPath(string path)
        {
            return System.IO.Path.GetFullPath(path);
        }
        private string getfolderpath()
        {


            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string foldername = "Temp NCCI";
            var folder = path + "/" + foldername;
            return folder;



        }

    


        //button, cbx events***********************************************************************************************
     

     


       



        //window events
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var scroll_viewer_height = scroll_main.ActualHeight;
            var scroll_viewer_width = scroll_main.ActualWidth;

            grid_main.Width = scroll_viewer_width;
            // grid_main.Height = scroll_viewer_height;
        }
        private void dg_inventory_GotFocus(object sender, RoutedEventArgs e)
        {

        }
        private void Window_Closed(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }









        //Mouse Events******************************************************************************************************




        //click events

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

       
            // DataGr  ClearFilter();
            Modify sw = new Modify(this,null);

            if (dg_inventory.SelectedItem != null) { sw.DataContext = dg_inventory.SelectedItem; }
            else
            if (dg_field_equipment.SelectedItem != null) { sw.DataContext = dg_field_equipment.SelectedItem; }

            sw.Show();

            //other way to get anonymous types without constructor**************
            //System.Type type = dg_inventory.SelectedItem.GetType(); 
            //Modify_Form.txt_serial_number.Text  = (string)type.GetProperty("Serial_Number").GetValue(dg_inventory.SelectedItem, null);


        }
        private void btn_new_equip_Click(object sender, RoutedEventArgs e)
        {
            New new_form = new New(this);
            new_form.Show();

        }


       

     

        private void btn_export_Click(object sender, RoutedEventArgs e)
        {
            //foreach (var process in Process.GetProcessesByName("excel"))
            //{
            //    process.Kill();
            //}



            if (bwexport.IsBusy != true)
            {
                media_load.Visibility = Visibility.Visible;
                bwexport.RunWorkerAsync();

            }









        }
        private void btn_search_Click(object sender, RoutedEventArgs e)
        {


            search s_form = new search();
            s_form.Show();

        }






        //datagridevents******************************************************************************************************
        private void dgInventory_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        { //get the information about the property that is auto-generating a column
            var pd = e.PropertyDescriptor as PropertyDescriptor; //requires using System.ComponentModel;

            //if our custom column doesn't exist for this property, don't show the column
            if (!(pd.Attributes[typeof(DGDisplayAttribute)] is DGDisplayAttribute attr))
            {
                e.Cancel = true;
                return;
            }

            // set the column header if one was provided
            if (!string.IsNullOrEmpty(attr.HeaderName))
            {
                e.Column.Header = attr.HeaderName;
            }

            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";

        }
        private void dg_field_equipment_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var pd = e.PropertyDescriptor as PropertyDescriptor; //requires using System.ComponentModel;

            //if our custom column doesn't exist for this property, don't show the column
            if (!(pd.Attributes[typeof(DGDisplayAttribute_Field)] is DGDisplayAttribute_Field attr))
            {
                e.Cancel = true;
                return;
            }

            // set the column header if one was provided
            if (!string.IsNullOrEmpty(attr.HeaderName))
            {
                e.Column.Header = attr.HeaderName;
            }

            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
        }
        private void dg_history_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            { //get the information about the property that is auto-generating a column
                var pd = e.PropertyDescriptor as PropertyDescriptor; //requires using System.ComponentModel;

                //if our custom column doesn't exist for this property, don't show the column
                if (!(pd.Attributes[typeof(DGDisplayAttribute_History)] is DGDisplayAttribute_History attr))
                {
                    e.Cancel = true;
                    return;
                }

                // set the column header if one was provided
                if (!string.IsNullOrEmpty(attr.HeaderName))
                {
                    e.Column.Header = attr.HeaderName;
                }

                if (e.PropertyType == typeof(System.DateTime))
                    (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
            }
        }


        //Querires

        public void refresh_field()
        {

            //dg_inventory.ClearValue(ItemsControl.ItemsSourceProperty);

           

            ////find field inventory

            ////select from Equipment class and put into InventoryItem class so on updatedatabase doesnt wipe out datagrid selections.
            ////search by location

            var context = new EquipmentEntities();
            var query1 = (from a in context.Equipments
                          select new InventoryItem
                          {

                              Serial_Number = a.Serial_Number,
                              Make = a.Make,
                              Model = a.Model,
                              Deployed_To = a.Deployed_To,
                              Machine_Name = a.Machine_Name,
                              Equipment_Type = a.Eq_Type,
                              Conway_Tag = a.Conway_Tag,
                              Status = a.Status,
                              Notes = a.Notes,
                              Field_Equipment = a.Field,
                              Create_User = a.Create_User,
                              Create_Date = a.Create_Date ?? DateTime.MinValue
                          }).ToList();

            DataContext = query1;




        }











        public void summary()
        {

            var context = new EquipmentEntities();
            var query = (from a in context.Equipments
                         where a.Eq_Type.Equals("Laptop") && a.Status.Equals("Deployed")
                         select a).Count();

            lbl_laptop.Content = "Deployed Laptops: " + query.ToString();

            query = (from a in context.Equipments
                     where a.Eq_Type.Equals("Laptop") && a.Status.Equals("In Server Room")
                     select a).Count();

            lbl_laptop_back.Content = "Laptops in Storage: " + query.ToString();


            query = (from a in context.Equipments
                     where a.Eq_Type.Equals("Desktop") && a.Status.Equals("Deployed")
                     select a).Count();
            lbl_desktop.Content = "Deployed Desktops: " + query.ToString();


            query = (from a in context.Equipments
                     where a.Eq_Type.Equals("Desktop") && a.Status.Equals("In Server Room")
                     select a).Count();
            lbl_desktop_back.Content = "Desktops in storage: " + query.ToString();


            query = (from a in context.Equipments
                     where a.Eq_Type.Equals("Printer") //&& a.Status.Equals("Deployed")
                     select a).Count();

            lbl_printer.Content = "Depolyed Printers: " + query.ToString();






        }



        //functions

        public static DataTable CreateDataTable(IEnumerable source)
        {
            var table = new DataTable();
            int index = 0;
            var properties = new List<PropertyInfo>();
            foreach (var obj in source)
            {
                if (index == 0)
                {
                    foreach (var property in obj.GetType().GetProperties())
                    {
                        if (Nullable.GetUnderlyingType(property.PropertyType) != null)
                        {
                            continue;
                        }
                        properties.Add(property);
                        table.Columns.Add(new DataColumn(property.Name, property.PropertyType));
                    }
                }
                object[] values = new object[properties.Count];
                for (int i = 0; i < properties.Count; i++)
                {
                    values[i] = properties[i].GetValue(obj);
                }
                table.Rows.Add(values);
                index++;
            }
            return table;
        }



        //media
        private void media_load_MediaEnded(object sender, RoutedEventArgs e)
        {
            media_load.Position = TimeSpan.FromMilliseconds(1);
        }



    }
}


