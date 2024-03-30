using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Helper
{
    public static class DataGridViewHelper
    {
        public static void InitializeColumns<T>(DataGridView dataGridView)
        {
            dataGridView.AutoGenerateColumns = false;
            var properties = typeof(T).GetProperties()
                .Where(
                      p => p.PropertyType != typeof(int) &&
                      !(typeof(IEnumerable).IsAssignableFrom(p.PropertyType) &&
                      p.PropertyType != typeof(string))
                      && !(p.PropertyType.IsClass && p.PropertyType != typeof(string))
                    );

            foreach (var prop in properties)
            {
                var column = new DataGridViewTextBoxColumn();
                column.Name = prop.Name;
                column.HeaderText = prop.Name;
                column.DataPropertyName = prop.Name;
                column.ValueType = prop.PropertyType;
                dataGridView.Columns.Add(column);
            }

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
