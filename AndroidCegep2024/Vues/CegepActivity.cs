using Android.Content;
using Android.Views;
using AndroidCegep2024.Adapters;
using AndroidCegep2024.Utils;
using AndroidCegep2024.Controleurs;
using AndroidCegep2024.DTOs;

namespace AndroidCegep2024.Vues
{
    /// <summary>
    /// Classe de type Activité pour l'affichage des Cégeps et l'ajout d'un Cégep.
    /// </summary>
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class CegepActivity : Activity
    {
        /// <summary>
        /// Liste de garderies.
        /// </summary>
        private CegepDTO[] listeCegep;

        /// <summary>
        /// Adapteur de la liste de Cégeps.
        /// </summary>
        private ListeCegepAdapter adapteurListeCegep;

        /// <summary>
        /// Attribut représentant le champ d'édition du nom du Cégep pour l'ajout d'un Cégep.
        /// </summary>
        private EditText edtNomCegep;

        /// <summary>
        /// Attribut représentant le champ d'édition de l'adresse du Cégep pour l'ajout d'un Cégep.
        /// </summary>
        private EditText edtAdresseCegep;

        /// <summary>
        /// Attribut représentant le champ d'édition de la ville du Cégep pour l'ajout d'un Cégep.
        /// </summary>
        private EditText edtVilleCegep;

        /// <summary>
        /// Attribut représentant le champ d'édition de la province du Cégep pour l'ajout d'un Cégep.
        /// </summary>
        private EditText edtProvinceCegep;

        /// <summary>
        /// Attribut représentant le champ d'édition du code postal du Cégep pour l'ajout d'un Cégep.
        /// </summary>
        private EditText edtCodePostalCegep;

        /// <summary>
        /// Attribut représentant le champ d'édition du téléphone du Cégep pour l'ajout d'un Cégep.
        /// </summary>
        private EditText edtTelephoneCegep;

        /// <summary>
        /// Attribut représentant le champ d'édition du courriel du Cégep pour l'ajout d'un Cégep.
        /// </summary>
        private EditText edtCourrielCegep;

        /// <summary>
        /// Attribut représentant le bouton pour l'ajout d'un Cégep.
        /// </summary>
        private Button btnAjouterCegep;

        /// <summary>
        /// Attribut représentant le listView pour la liste des Cégeps.
        /// </summary>
        private ListView listViewCegep;

        /// <summary>
        /// Méthode de service appelée lors de la création de l'activité.
        /// </summary>
        /// <param name="savedInstanceState">État de l'activité.</param>
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
                        DialoguesUtils.AfficherToasts(this, nom + " ajouté !!!");
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
                //On initialise les paramètres avant de lancer la nouvelle activité.
                activiteCegepDetails.PutExtra("paramNomCegep", listeCegep[e.Position].Nom);
                //On démarre la nouvelle activité.
                StartActivity(activiteCegepDetails);
            };
        }

        /// <summary>
        /// Méthode de service appelée lors du retour en avant plan de l'activité.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();

            RafraichirInterfaceDonnees();
        }

        /// <summary>
        /// Méthode permettant de rafraichir la liste des Cégeps...
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

        /// <summary>Méthode de service permettant d'initialiser le menu de l'activité.</summary>
        /// <param name="menu">Le menu à construire.</param>
        /// <returns>Retourne True si l'optionMenu est bien créé.</returns>
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Cegep_ActivityMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        /// <summary>Méthode de service permettant de capter l'évenement exécuté lors d'un choix dans le menu.</summary>
        /// <param name="item">L'item sélectionné.</param>
        /// <returns>Retourne si un option à été sélectionné avec succès.</returns>
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