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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для AboutCalculator.xaml
    /// </summary>
    public partial class AboutCalculator : Window
    {
        public AboutCalculator()
        {
            InitializeComponent();

            //TranslateTransform translateTransform = new TranslateTransform();
            //Titr.RenderTransform = translateTransform;
            //DoubleAnimation animation = new DoubleAnimation(0, -200, TimeSpan.FromSeconds(5));
            //translateTransform.BeginAnimation(TranslateTransform.YProperty, animation);

            Anim();

            async void Anim()
            {
                TranslateTransform transformLeft = new TranslateTransform();
                TranslateTransform transformRight = new TranslateTransform();
                TranslateTransform transformLeft2 = new TranslateTransform();
                TranslateTransform transformRight2 = new TranslateTransform();
                TranslateTransform transformLeft3 = new TranslateTransform();
                TranslateTransform transformRight3 = new TranslateTransform();
                TranslateTransform transformLeft4 = new TranslateTransform();
                TranslateTransform transformRight4 = new TranslateTransform();
                TranslateTransform transformLeft5 = new TranslateTransform();
                TranslateTransform transformRight5 = new TranslateTransform();
                DoubleAnimation animTitrOpUp = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(2));
                DoubleAnimation animTitrOpDown = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(2));
                DoubleAnimation animHeadLeft = new DoubleAnimation(-100, 0, TimeSpan.FromSeconds(1));
                DoubleAnimation animTextRight = new DoubleAnimation(100, 0, TimeSpan.FromSeconds(1));

                AuthorsText.BeginAnimation(TextBlock.OpacityProperty, animTitrOpUp);

                await Task.Delay(1000);

                Heading1.RenderTransform = transformLeft;
                Text1.RenderTransform = transformRight;
                
                transformLeft.BeginAnimation(TranslateTransform.XProperty, animHeadLeft);
                transformRight.BeginAnimation(TranslateTransform.XProperty, animTextRight);

                Heading1.BeginAnimation(TextBlock.OpacityProperty, animTitrOpUp);
                Text1.BeginAnimation(TextBlock.OpacityProperty, animTitrOpUp);

                await Task.Delay(2000);

                Heading1.BeginAnimation(TextBlock.OpacityProperty, animTitrOpDown);
                Text1.BeginAnimation(TextBlock.OpacityProperty, animTitrOpDown);

                await Task.Delay(1000);

                // --------------------------------------------------------------------------------

                Heading2.RenderTransform = transformLeft2;
                Text2.RenderTransform = transformRight2;

                transformLeft2.BeginAnimation(TranslateTransform.XProperty, animHeadLeft);
                transformRight2.BeginAnimation(TranslateTransform.XProperty, animTextRight);

                Heading2.BeginAnimation(TextBlock.OpacityProperty, animTitrOpUp);
                Text2.BeginAnimation(TextBlock.OpacityProperty, animTitrOpUp);

                await Task.Delay(2000);

                Heading2.BeginAnimation(TextBlock.OpacityProperty, animTitrOpDown);
                Text2.BeginAnimation(TextBlock.OpacityProperty, animTitrOpDown);

                await Task.Delay(1000);

                // --------------------------------------------------------------------------------

                Heading3.RenderTransform = transformLeft3;
                Text3.RenderTransform = transformRight3;

                transformLeft3.BeginAnimation(TranslateTransform.XProperty, animHeadLeft);
                transformRight3.BeginAnimation(TranslateTransform.XProperty, animTextRight);

                Heading3.BeginAnimation(TextBlock.OpacityProperty, animTitrOpUp);
                Text3.BeginAnimation(TextBlock.OpacityProperty, animTitrOpUp);

                await Task.Delay(2000);

                Heading3.BeginAnimation(TextBlock.OpacityProperty, animTitrOpDown);
                Text3.BeginAnimation(TextBlock.OpacityProperty, animTitrOpDown);

                await Task.Delay(1000);

                // --------------------------------------------------------------------------------

                Heading4.RenderTransform = transformLeft4;
                Text4.RenderTransform = transformRight4;

                transformLeft4.BeginAnimation(TranslateTransform.XProperty, animHeadLeft);
                transformRight4.BeginAnimation(TranslateTransform.XProperty, animTextRight);

                Heading4.BeginAnimation(TextBlock.OpacityProperty, animTitrOpUp);
                Text4.BeginAnimation(TextBlock.OpacityProperty, animTitrOpUp);

                await Task.Delay(1000);

                Heading4.BeginAnimation(TextBlock.OpacityProperty, animTitrOpDown);
                Text4.BeginAnimation(TextBlock.OpacityProperty, animTitrOpDown);

                AuthorsText.BeginAnimation(TextBlock.OpacityProperty, animTitrOpDown);

                await Task.Delay(2000);

                StudentText.BeginAnimation(TextBlock.OpacityProperty, animTitrOpUp);

                // --------------------------------------------------------------------------------

                Heading5.RenderTransform = transformLeft5;
                Text5.RenderTransform = transformRight5;

                transformLeft5.BeginAnimation(TranslateTransform.XProperty, animHeadLeft);
                transformRight5.BeginAnimation(TranslateTransform.XProperty, animTextRight);

                Heading5.BeginAnimation(TextBlock.OpacityProperty, animTitrOpUp);
                Text5.BeginAnimation(TextBlock.OpacityProperty, animTitrOpUp);
                Logo.BeginAnimation(TextBlock.OpacityProperty, animTitrOpUp);

                //await Task.Delay(10000);

                //Heading5.BeginAnimation(TextBlock.OpacityProperty, animTitrOpDown);
                //Text5.BeginAnimation(TextBlock.OpacityProperty, animTitrOpDown);

                //await Task.Delay(1000);

            }
        }

        private void CloseButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
