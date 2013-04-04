using System.Windows.Controls;
using System.Windows.Input;
using YDirect.ViewModel;

namespace YDirect.View
{
    /// <summary>
    /// Interaction logic for CampaignsListTabView.xaml
    /// </summary>
    public partial class CampaignsListTabView : UserControl
    {
        public CampaignsListTabView()
        {
            InitializeComponent();
        }

        private void HandleMouseDoubleClickRow(object sender, MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            if (row == null || !row.IsSelected) 
                return;

            var viewModel = (CampaignsListTabViewModel)DataContext;
            viewModel.OpenSelectedCampaignTab(row.DataContext);
        }
    }
}
