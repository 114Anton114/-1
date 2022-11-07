using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UPOne.SovNasProg;

namespace UPOne.MnogPage.Main
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public PageMain()
        {
            InitializeComponent();
            private void BtnLogin_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    var data = ConnectionClass.connectPoint.User.FirstOrDefault(
                            x => x.Login == TextBoxLogin.Text && x.Password == PassBoxLogin.Password
                        );

                    if (data == null)
                        MessageBox.Show("Пользователя не существует по данному логину.",
                                        "Уведомление",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);
                    else
                    {
                        switch (data.RoleId)
                        {
                            case 1:
                                FrameClass.MainWindFrame.Navigate(new PageMainAdmin());
                                break;
                            case 2:
                                FrameClass.MainWindFrame.Navigate(new PageMainClient());
                                break;
                            default:
                                MessageBox.Show("Данное представление невозможно вывести.",
                                     "Критическая ошибка",
                                     MessageBoxButton.OK,
                                     MessageBoxImage.Warning);
                                break;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
    }
}
