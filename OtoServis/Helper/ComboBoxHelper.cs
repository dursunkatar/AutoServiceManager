using OtoServis.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Helper
{
    public static class ComboBoxHelper
    {
        public static void LoadData(ComboBox comboBox, object? dataSource,string displayMember,string valueMember)
        {
            comboBox.DataSource = dataSource;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
        }

        public static void SelectItemByValue<T>(ComboBox comboBox, T value)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (comboBox.Items[i] is TextValueDto<T> item && item.Value.Equals(value))
                {
                    comboBox.SelectedIndex = i;
                    break; 
                }
            }
        }

    }
}
