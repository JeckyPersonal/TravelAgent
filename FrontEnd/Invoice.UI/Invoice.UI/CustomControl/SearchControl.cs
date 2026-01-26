using Invoice.UI.CustomControl.EventArguments;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Invoice.UI.CustomControl
{
    public delegate void ButtonClickHandler(object sender, EventArgs e);
    public delegate void SearchCriteriaHandler(object sender, SearchCriteriaEventArgs e);

    public partial class SearchControl : UserControl
    {
        public event ButtonClickHandler OnSearchClickHandler;
        public event SearchCriteriaHandler OnSearchCriteriaAdded;
        public event SearchCriteriaHandler OnSearchCriteriaRemoved;

        private List<string> _fieldSource;

        public SearchControl()
        {
            InitializeComponent();
            this._fieldSource = new List<string>();
            this.flowPnlSearchCriteria.Visible = false;
        }

        public List<string> FieldSource
        {
            get
            {
                return _fieldSource;
            }
            set
            {
                this._fieldSource = value;
                this.cmbFieldName.DataSource = _fieldSource;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.cmbFieldName.SelectedIndex == -1)
                return;

            if (string.IsNullOrEmpty(this.txtSearchVal.Text))
                return;

            if (this.OnSearchClickHandler != null)
            {
                this.OnSearchClickHandler.Invoke(sender, e);
            }

            this.flowPnlSearchCriteria.Visible = true;
            SearchTag tag = new SearchTag();
            tag.FieldName = cmbFieldName.Text;
            tag.Operator = "Equals";
            tag.Value = txtSearchVal.Text;
            this.flowPnlSearchCriteria.Controls.Add(tag);
            this.txtSearchVal.Clear();
            this.cmbFieldName.SelectedIndex = -1;
            this.Refresh();
        }

        private void Tag_OnRemoveCriteriaHandler(object sender, EventArgs e)
        {
            this.flowPnlSearchCriteria.Visible = this.flowPnlSearchCriteria.Controls.Count == 0;
        }

        private void cmbFillValue_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void cmbFillValue_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) 
                this.btnSearch_Click(sender, e);
        }

        private void flowPnlSearchCriteria_ControlAdded(object sender, ControlEventArgs e)
        {
            SearchTag currentSearchTag = e.Control as SearchTag;
            if (this.OnSearchCriteriaAdded != null)
            {
                this.OnSearchCriteriaAdded(currentSearchTag, new SearchCriteriaEventArgs() { FieldName = currentSearchTag.FieldName, Value = currentSearchTag.Value, Opearator = currentSearchTag.Operator, Action = EventArguments.Action.Added });
            }
        }

        private void flowPnlSearchCriteria_ControlRemoved(object sender, ControlEventArgs e)
        {
            SearchTag currentSearchTag = e.Control as SearchTag;
            if (this.OnSearchCriteriaRemoved != null)
            {
                this.OnSearchCriteriaRemoved(currentSearchTag, new SearchCriteriaEventArgs() { FieldName = currentSearchTag.FieldName, Value = currentSearchTag.Value, Opearator = currentSearchTag.Operator, Action = EventArguments.Action.Removed });
            }
        }
    }
}
