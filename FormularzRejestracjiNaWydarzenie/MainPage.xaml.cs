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
            DataPicker.Date = new DateTime(2026,6,16);
        }

        private void LiczCene()
        {
            /********************************
            nazwa funkcji: LiczCene
            opis funkcji: liczy cenę całkowitą
            paramerty: brak
            zwracany typ i opis: brak
            autor: E.P.
            *********************************/

            cena = cenaWybranegoPakietu + 100 * liczbaDodatkowychOsob;
            CenaCalkowita.Text = "Cena całkowita: " + cena + " zł";
        }

        private void Data_DateSelected(object sender, DateChangedEventArgs e)
        {
            /********************************
            nazwa funkcji: Data_DateSelected
            opis funkcji: Sprawdza czy wybrana data jest dostępna
            paramerty: sender, e
            zwracany typ i opis: brak
            autor: E.P.
            *********************************/

            var dataPicker1 = DataPicker.Date.ToString();
            string dataPicker = dataPicker1.Substring(0, dataPicker1.Length - 9);

            if(dataPicker== "16.06.2026" ||  dataPicker== "18.06.2026" || dataPicker== "23.06.2026" )
            {
                poprawnaData = true;
                DataInfoLabel.TextColor = Colors.Black;
                DataInfoLabel.Text = "Wybrana data: " + dataPicker;
            }
            else
            {
                DataInfoLabel.TextColor = Colors.Red;
                DataInfoLabel.Text = "Termin niedostępny";
                poprawnaData = false;
            }
        }

        private void DodatkoweOsobyStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            /********************************
            nazwa funkcji: DodatkoweOsobyStepper_ValueChanged
            opis funkcji: pobiera liczbę osób dodatkowych i wywołuje funkcję LiczCene
            paramerty: sender, e
            zwracany typ i opis: brak
            autor: E.P.
            *********************************/

            liczbaDodatkowychOsob = (int)DodatkoweOsobyStepper.Value;
            DodatkoweOsobyLabel.Text = "Osoby dodatkowe: " + liczbaDodatkowychOsob;
            LiczCene();
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            /********************************
            nazwa funkcji: RadioButton_CheckedChanged
            opis funkcji: sprawdza, który pakiet został wybrany i wywołuje funkcję LiczCene
            paramerty: sender, e
            zwracany typ i opis: brak
            autor: E.P.
            *********************************/

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
            /********************************
            nazwa funkcji: Button_Clicked
            opis funkcji: sprawdza, czy wprowadzone dane są poprawne i wyświetla komunikat z podsumowaniem
            paramerty: sender, e
            zwracany typ i opis: brak
            autor: E.P.
            *********************************/

            if (ImieINazwiskoEntry.Text!=null && EmailEntry.Text!=null && ImieINazwiskoEntry.Text != "" && EmailEntry.Text != "" && FirmaPicker.SelectedIndex!=-1 && poprawnaData==true)
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
