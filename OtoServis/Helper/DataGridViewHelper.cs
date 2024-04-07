using System.Collections;

namespace OtoServis.Helper
{
    public static class DataGridViewHelper
    {
        public static (bool, T?) GetSelectedValue<T>(DataGridView dataGridView) where T : class
        {
            var currentRow = dataGridView.CurrentRow;
            if (currentRow == null) return (false, default);
            var selectedItem = currentRow.DataBoundItem as T;
            if (selectedItem == null) return (false, default);

            return (true, selectedItem);
        }

        public static void LoadData<T>(DataGridView dataGridView, List<T> data) where T : class
        {
            dataGridView.Columns.Clear();
            dataGridView.AutoGenerateColumns = false;
            var properties = typeof(T).GetProperties()
                .Where(
                      p => !(typeof(IEnumerable).IsAssignableFrom(p.PropertyType) &&
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
            dataGridView.DataSource = data;
        }
    }
}
