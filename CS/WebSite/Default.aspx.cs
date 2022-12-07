using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page {

    private bool getRowEnabledStatus(int VisibleIndex) {
        int CategoryID = Convert.ToInt32(grid.GetRowValues(VisibleIndex, "CategoryID"));

        return (CategoryID != 2) ? true : false;
    }

    protected void grid_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e) {
        if (e.ButtonType != ColumnCommandButtonType.SelectCheckbox) return;

        bool rowEnabled = getRowEnabledStatus(e.VisibleIndex);
        e.Enabled = rowEnabled;
    }
    protected void grid_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e) {
        List<int> indexesUnselected = Session["WebManagement_IndexesUnselected"] as List<int>;
        List<int> indexesSelected = Session["WebManagement_IndexesSelected"] as List<int>;
        e.Properties["cpIndexesUnselected"] = indexesUnselected;
        e.Properties["cpIndexesSelected"] = indexesSelected;
    }
    protected void cbAll_Init(object sender, EventArgs e) {
        List<int> indexesUnselected = new List<int>();
        List<int> indexesSelected = new List<int>();

        for (int i = 0; i < grid.VisibleRowCount; i++) {
            bool rowEnabled = getRowEnabledStatus(i);
            if (rowEnabled) indexesSelected.Add(i);
            else indexesUnselected.Add(i);
        }
        Session["WebManagement_IndexesUnselected"] = indexesUnselected;
        Session["WebManagement_IndexesSelected"] = indexesSelected;
    }
    protected void grid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e) {
        for (int i = 0; i < grid.VisibleRowCount; i++) {
            bool rowEnabled = getRowEnabledStatus(i);

            if (rowEnabled && e.Parameters == "true")
                grid.Selection.SelectRow(i);
            else
                grid.Selection.UnselectRow(i);
        }
    }
    protected void grid_DataBound(object sender, EventArgs e) {
        grid.JSProperties["cpPageSize"] = grid.SettingsPager.PageSize;
    }

    protected void ASPxButton1_Click(object sender, EventArgs e) {
        grid.Selection.SelectAll();
    }
}