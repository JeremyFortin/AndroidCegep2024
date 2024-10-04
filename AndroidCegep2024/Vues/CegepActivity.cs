using Android.Content;
using Android.Views;
using AndroidCegep2024.Adapters;
using AndroidCegep2024.Utils;
using AndroidCegep2024.Controleurs;
using AndroidCegep2024.DTOs;

namespace AndroidCegep2024.Vues
{
    /// <summary>
    /// Classe de type Activit� pour l'affichage des C�geps et l'ajout d'un C�gep.
    /// </summary>
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class CegepActivity : Activity
    {
        /// <summary>
        /// Liste de garderies.
        /// </summary>
        private CegepDTO[] listeCegep;

        /// <summary>
        /// Adapteur de la liste de C�geps.
        /// </summary>
        private ListeCegepAdapter adapteurListeCegep;

        /// <summary>
        /// Attribut repr�sentant le champ d'�dition du nom du C�gep pour l'ajout d'un C�gep.
        /// </summary>
        private EditText edtNomCegep;

        /// <summary>
        /// Attribut repr�sentant le champ d'�dition de l'adresse du C�gep pour l'ajout d'un C�gep.
        /// </summary>
        private EditText edtAdresseCegep;

        /// <summary>
        /// Attribut repr�sentant le champ d'�dition de la ville du C�gep pour l'ajout d'un C�gep.
        /// </summary>
        private EditText edtVilleCegep;

        /// <summary>
        /// Attribut repr�sentant le champ d'�dition de la province du C�gep pour l'ajout d'un C�gep.
        /// </summary>
        private EditText edtProvinceCegep;

        /// <summary>
        /// Attribut repr�sentant le champ d'�dition du code postal du C�gep pour l'ajout d'un C�gep.
        /// </summary>
        private EditText edtCodePostalCegep;

        /// <summary>
        /// Attribut repr�sentant le champ d'�dition du t�l�phone du C�gep pour l'ajout d'un C�gep.
        /// </summary>
        private EditText edtTelephoneCegep;

        /// <summary>
        /// Attribut repr�sentant le champ d'�dition du courriel du C�gep pour l'ajout d'un C�gep.
        /// </summary>
        private EditText edtCourrielCegep;

        /// <summary>
        /// Attribut repr�sentant le bouton pour l'ajout d'un C�gep.
        /// </summary>
        private Button btnAjouterCegep;

        /// <summary>
        /// Attribut repr�sentant le listView pour la liste des C�geps.
        /// </summary>
        private ListView listViewCegep;

        /// <summary>
        /// M�thode de service appel�e lors de la cr�ation de l'activit�.
        /// </summary>
        /// <param name="savedInstanceState">�tat de l'activit�.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Cegep_Activity);

            edtNomCegep = FindViewById<EditText>(Resource.Id.edtNomInfo);
            edtAdresseCegep = FindViewById<EditText>(Resource.Id.edtAdresseInfo);
            edtVilleCegep = FindViewById<EditText>(Resource.Id.edtVilleInfo);
            edtProvinceCegep = FindViewById<EditText>(Resource.Id.edtProvinceInfo);
            edtCodePostalCegep = FindViewById<EditText>(Resource.Id.edtCodePostalInfo);
            edtTelephoneCegep = FindViewById<EditText>(Resource.Id.edtTelephoneInfo);
            edtCourrielCegep = FindViewById<EditText>(Resource.Id.edtCourrielInfo);

            btnAjouterCegep = FindViewById<Button>(Resource.Id.btnAjouter);
            btnAjouterCegep.Click += delegate
            {
                if (edtAdresseCegep.Text.Length > 0 && edtVilleCegep.Text.Length > 0 && edtProvinceCegep.Text.Length > 0 && edtCodePostalCegep.Text.Length > 0 && edtTelephoneCegep.Text.Length > 0 && edtCourrielCegep.Text.Length > 0)
                {
                    try
                    {
                        string nom = edtNomCegep.Text;
                        CegepControleur.Instance.AjouterCegep(new CegepDTO(edtNomCegep.Text, edtAdresseCegep.Text, edtVilleCegep.Text, edtProvinceCegep.Text, edtCodePostalCegep.Text, edtTelephoneCegep.Text, edtCourrielCegep.Text));
                        RafraichirInterfaceDonnees();
                        DialoguesUtils.AfficherToasts(this, nom + " ajout� !!!");
                    }
                    catch (Exception ex)
                    {
                        DialoguesUtils.AfficherMessageOK(this, "Erreur", ex.Message);
                    }
                }
                else
                    DialoguesUtils.AfficherMessageOK(this, "Erreur", "Veuillez remplir tous les champs...");
            };

            listViewCegep = FindViewById<ListView>(Resource.Id.listViewCegep);
            listViewCegep.ItemClick += (sender, e) =>
            {
                Intent activiteCegepDetails = new Intent(this, typeof(CegepDetailsActivity));
                //On initialise les param�tres avant de lancer la nouvelle activit�.
                activiteCegepDetails.PutExtra("paramNomCegep", listeCegep[e.Position].Nom);
                //On d�marre la nouvelle activit�.
                StartActivity(activiteCegepDetails);
            };
        }

        /// <summary>
        /// M�thode de service appel�e lors du retour en avant plan de l'activit�.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();

            RafraichirInterfaceDonnees();
        }

        /// <summary>
        /// M�thode permettant de rafraichir la liste des C�geps...
        /// </summary>
        private void RafraichirInterfaceDonnees()
        {
            try
            {
                listeCegep = CegepControleur.Instance.ObtenirListeCegep().ToArray();
                adapteurListeCegep = new ListeCegepAdapter(this, listeCegep);
                listViewCegep.Adapter = adapteurListeCegep;
                edtNomCegep.Text = edtAdresseCegep.Text = edtVilleCegep.Text = edtProvinceCegep.Text = edtCodePostalCegep.Text = edtTelephoneCegep.Text = edtCourrielCegep.Text = "";
                edtNomCegep.RequestFocus();
            }
            catch (Exception ex)
            {
                DialoguesUtils.AfficherMessageOK(this, "Erreur", ex.Message);
            }
        }

        /// <summary>M�thode de service permettant d'initialiser le menu de l'activit�.</summary>
        /// <param name="menu">Le menu � construire.</param>
        /// <returns>Retourne True si l'optionMenu est bien cr��.</returns>
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Cegep_ActivityMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        /// <summary>M�thode de service permettant de capter l'�venement ex�cut� lors d'un choix dans le menu.</summary>
        /// <param name="item">L'item s�lectionn�.</param>
        /// <returns>Retourne si un option � �t� s�lectionn� avec succ�s.</returns>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.Quitter:
                    Finish();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}