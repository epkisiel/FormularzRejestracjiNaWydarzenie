namespace FormularzRejestracjiNaWydarzenie
{
    public partial class MainPage : ContentPage
    {
        int liczbaDodatkowychOsob = 0;
        string wybranyPakiet = "Basic";
        double cenaWybranegoPakietu = 200;
        double cena=200;
        bool poprawnaData = true;

        public MainPage()
        {
            InitializeComponent();
            RadioButtonBasic.IsChecked = true;
            DataPicker.MinimumDate = DateTime.Today;
            DataPicker.Date = new DateTime(2026,2,16);
        }

        private void LiczCene()
        {
            cena = cenaWybranegoPakietu + 100 * liczbaDodatkowychOsob;
            CenaCalkowita.Text = "Cena całkowita: " + cena + " zł";
        }

        private void Data_DateSelected(object sender, DateChangedEventArgs e)
        {
            var dataPicker1 = DataPicker.Date.ToString();
            string dataPicker = dataPicker1.Substring(0, dataPicker1.Length - 9);

            if(dataPicker!= "16.02.2026" &&  dataPicker!= "18.02.2026" && dataPicker!= "23.02.2026" && dataPicker!=null && dataPicker!="")
            {
                DataInfoLabel.IsVisible = true;
                poprawnaData = false;
            }
            else
            {
                poprawnaData= true;
                DataInfoLabel.IsVisible=false;
            }
        }

        private void DodatkoweOsobyStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            liczbaDodatkowychOsob=(int)DodatkoweOsobyStepper.Value;
            LiczCene();
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                var radioButton = (RadioButton)sender;
                wybranyPakiet = radioButton.Value.ToString();
                if (wybranyPakiet == "Basic")
                {
                    cenaWybranegoPakietu = 200;
                }
                else if (wybranyPakiet == "Standard")
                {
                    cenaWybranegoPakietu = 350;
                }
                else if (wybranyPakiet == "Premium")
                {
                    cenaWybranegoPakietu = 500;
                }
                LiczCene();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(ImieINazwiskoEntry.Text!=null && EmailEntry.Text!=null && ImieINazwiskoEntry.Text != "" && EmailEntry.Text != "" && FirmaPicker.SelectedIndex!=-1 && poprawnaData)
            {
                string imieINazwisko=ImieINazwiskoEntry.Text;
                string email = EmailEntry.Text;
                string firma = FirmaPicker.SelectedItem.ToString();

                InfromacjaLabel.IsVisible = false;
                DisplayAlert("Podsumowanie", "Imię i nazwisko: " + imieINazwisko + "\nEmail: " + email + "\nFirma: " + firma + "\nCena: " + cena, "Zamknij");
            }
            else
            {
                InfromacjaLabel.IsVisible=true;
            }
        }
    }
}
