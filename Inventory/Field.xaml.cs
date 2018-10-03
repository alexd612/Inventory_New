using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Inventory
{
    /// <summary>
    /// Interaction logic for Field.xaml
    /// </summary>


    public class FieldInventory
    {
        public int Mouse_Count { get; set; }
        public int Monitor_Count { get; set; }
        public int Keyboard_Count { get; set; }
        public int Dock_Count { get; set; }
        public string Printer { get; set; }
        public string Office_Location { get; set; }






    }
    public partial class Field : Window
    {
        //pass modify form

        //is shown evet
        bool _shown;

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            if (_shown)
                return;

            _shown = true;


            //check to see if equipment already has locations
            //get equipment id with serial number
            var context = new EquipmentEntities();

            var query = (from a in context.Equipments
                         where a.Serial_Number == serial_number
                         select a.Equipment_ID).Single();
            var equip_id = query;
            int eid = Convert.ToInt32(equip_id);

            //check to see if eq id is in field table, if so display locations in listbox

            var querycheck = (from a in context.Field_Equipment
                              where a.Equipment_ID == eid
                              select a.Field_ID
                              ).ToList();
            if (querycheck.Count != 0)
            {
                MessageBox.Show("Office locations have been found. Please double click on a location to edit.", "Office Locations");
                //show office locations
                var queryloactions = (from a in context.Field_Equipment
                                      where a.Equipment_ID == eid
                                      select a.Office_Location).ToList();

                foreach (var i in queryloactions)
                {

                    listbox_locations.Items.Add(i.ToString());

                }

                listbox_locations.BorderBrush = Brushes.Blue;
                return;
            }

            listbox_locations.BorderBrush = null;
        }

        public FieldInventory field_item { get; set; }
  

        public string serial_number;
        public int eid;

      


        public Field()
        {
            InitializeComponent();
            field_item = new FieldInventory();
            DataContext = field_item;
       
        }


        //button events************************************************************************************************
        private void btn_sumbit_Click(object sender, RoutedEventArgs e)
        {


            if (field_item.Office_Location == null){ MessageBox.Show("Please select an office location. Cannot send field equipment.", "Warning"); return;}

            // pull back equipment id to insert into field table
            var context = new EquipmentEntities();
            var query = (from a in context.Equipments
                         where a.Serial_Number == serial_number
                         select a.Equipment_ID).Single();
            var equip_id = query;
            int eid = Convert.ToInt32(equip_id);



            //update field table if true figure out if update or new. 
            int field_id = 0;
            try
            {
                var query_id = (from a in context.Field_Equipment
                                where (a.Equipment_ID == eid && a.Office_Location == field_item.Office_Location.ToString())
                                select a.Field_ID).Single();

                field_id = Convert.ToInt32(query_id);
            }

            catch(System.InvalidOperationException)
            {
                //insert new reocord into field equipment
                var field_equip = new Field_Equipment
                {
                    Equipment_ID = eid,
                    Mouse_Count = field_item.Mouse_Count,
                    Dock_Station_Count = field_item.Dock_Count,
                    Keyboard_Count = field_item.Keyboard_Count,
                    Monitor_Count = field_item.Monitor_Count,
                    Printer = field_item.Printer,
                    Office_Location = field_item.Office_Location

                };

                context.Field_Equipment.Add(field_equip);
                context.SaveChanges();


            }

            if (field_id != 0)
            {

                //update equipment table with new information
                var query_update = (from a in context.Field_Equipment
                                    where a.Field_ID == field_id
                                    select a).First();
                //   update fields

                query_update.Keyboard_Count = Convert.ToInt16(this.DataContext.GetType().GetProperty("Keyboard_Count").GetValue(this.DataContext, null).ToString());
                query_update.Mouse_Count = Convert.ToInt16(this.DataContext.GetType().GetProperty("Mouse_Count").GetValue(this.DataContext, null).ToString());
                query_update.Monitor_Count = Convert.ToInt16(this.DataContext.GetType().GetProperty("Monitor_Count").GetValue(this.DataContext, null).ToString());
                query_update.Dock_Station_Count = Convert.ToInt16(this.DataContext.GetType().GetProperty("Dock_Count").GetValue(this.DataContext, null).ToString());
                query_update.Printer = this.DataContext.GetType().GetProperty("Printer").GetValue(this.DataContext, null).ToString();

                context.SaveChanges();

            }

    
            
          
            //update field column on equipment table******************************************************************************************

            var query1 = (from a in context.Equipments
                          where a.Equipment_ID.Equals(equip_id)
                          select a).First();
            //   update fields

            query1.Field = "Y";
            
            context.SaveChanges();


            MessageBoxResult result = MessageBox.Show("Would you like to add another location?", "Field Equipment", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    //clear all controls in grid

                    clear_form();

                    break;


                case MessageBoxResult.No:
                    this.Close();
                    break;
                case MessageBoxResult.Cancel:

                    break;
            }




        }

        private void listbox_locations_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listbox_locations.SelectedItem == null) { return; }

            this.DataContext = null;


            string search_location = listbox_locations.SelectedItem.ToString();

            //get field id number with equip
            var context = new EquipmentEntities();
            var query_id = (from a in context.Field_Equipment
                            where (a.Equipment_ID == eid && a.Office_Location == search_location)
                            select a.Field_ID).Single();

            int field_id = Convert.ToInt32(query_id);

            // serach for equipment associated with location

            var query = (from a in context.Field_Equipment
                         where a.Field_ID == field_id
                         select new FieldInventory
                         {
                             Mouse_Count = a.Mouse_Count ?? int.MinValue,
                             Monitor_Count = a.Monitor_Count ?? int.MinValue,
                             Keyboard_Count = a.Keyboard_Count ?? int.MinValue,
                             Dock_Count = a.Dock_Station_Count ?? int.MinValue,
                             Printer = a.Printer,
                             Office_Location = a.Office_Location

                         }).ToList();

            // this.DataContext = query;


            ////populate field_item which is the forms datacontext declared in intialize


            field_item.Office_Location = query.Select(o => o.Office_Location).Single();
            field_item.Dock_Count = query.Select(o => o.Dock_Count).Single();
            field_item.Monitor_Count = query.Select(o => o.Monitor_Count).Single();
            field_item.Mouse_Count = query.Select(o => o.Mouse_Count).Single();
            field_item.Keyboard_Count = query.Select(o => o.Keyboard_Count).Single();
            field_item.Printer = query.Select(o => o.Printer).Single();



            // field_item = new FieldInventory();
            DataContext = field_item;



        }

        //context menu events
        private void context_delete_Click(object sender, RoutedEventArgs e)
        {

            // pull back equipment id to insert into field table
            var context = new EquipmentEntities();
            var query = (from a in context.Equipments
                         where a.Serial_Number == serial_number
                         select a.Equipment_ID).Single();
            var equip_id = query;
            int eid = Convert.ToInt32(equip_id);



            //update field table if true figure out if update or new. 
            int field_id = 0;
           
              var query_id = (from a in context.Field_Equipment
                                where (a.Equipment_ID == eid && a.Office_Location == listbox_locations.SelectedItem.ToString())
                                select a.Field_ID).Single();

                field_id = Convert.ToInt32(query_id);

            //get field id


            using (var ctx = new EquipmentEntities())
            {
                var x = (from a in ctx.Field_Equipment
                         where a.Field_ID == field_id
                         select a).FirstOrDefault();

                ctx.Field_Equipment.Remove(x);
                ctx.SaveChanges();
            }

            MessageBox.Show("Equipment has been deleted.", "Complete");

            listbox_locations.Items.RemoveAt(listbox_locations.Items.IndexOf(listbox_locations.SelectedItem));

            return;
                



        }


        
        
        //Clear Code***************************************************************************************************

        private void clear_form()
        {
            foreach (UIElement x in this.grid_field.Children)
            {
                if (x is System.Windows.Controls.TextBox)
                {
                    ((System.Windows.Controls.TextBox)x).Text = "";

                }

                foreach (UIElement y in this.grid_field.Children)
                {
                    if (y is System.Windows.Controls.ComboBox)
                    {
                        ((System.Windows.Controls.ComboBox)y).SelectedIndex = 0;

                    }



                }









            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
        


        }

   
    }
}