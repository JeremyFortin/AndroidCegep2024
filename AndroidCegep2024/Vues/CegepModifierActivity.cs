using Android.Views;
using AndroidCegep2024.Controleurs;
using AndroidCegep2024.DTOs;
using AndroidCegep2024.Utils;

/// <summary>
/// Namespace pour les classes de type Vue.
/// </summary>
namespace AndroidCegep2024.Vues
{
    /// <summary>
    /// Classe de type Activité pour la modification d'un Cégep.
    /// </summary>
    [Activity(Label = "@string/app_name")]
    public class CegepModifierActivity : Activity
    {
        /// <summary>
        /// Attribut représentant le paramètre reçu de l'activité précédente.
        /// </summary>
        private string paramNomCegep;

        /// <summary>
        /// Attribut représentant le DTO du Cégep.
        /// </summary>
        private CegepDTO leCegep;

        /// <summary>
        /// Attribut représentant le champ d'édition du nom du Cégep pour la modification d'un Cégep. 
        /// </summary>
        private EditText edtNomCegepModifier;

        /// <summary>
        /// Attribut représentant le champ d'édition de l'adresse du Cégep pour la modification d'un Cégep.
        /// </summary>
        private EditText edtAdresseCegepModifier;

        /// <summary>
        /// Attribut représentant le champ d'édition de la ville du Cégep pour la modification d'un Cégep.
        /// </summary>
        private EditText edtVilleCegepModifier;

        /// <summary>
        /// Attribut représentant le champ d'édition de la province du Cégep pour la modification d'un Cégep.
        /// </summary>
        private EditText edtProvinceCegepModifier;

        /// <summary>
        /// Attribut représentant le champ d'édition du code postal du Cégep pour la modification d'un Cégep.
        /// </summary>
        private EditText edtCodePostalCegepModifier;

        /// <summary>
        /// Attribut représentant le champ d'édition du téléphone du Cégep pour la modification d'un Cégep.
        /// </summary>
        private EditText edtTelephoneCegepModifier;

        /// <summary>
        /// Attribut représentant le champ d'édition du courriel du Cégep pour la modification d'un Cégep.
        /// </summary>
        private EditText edtCourrielCegepModifier;

        /// <summary>
        /// Attribut représentant le bouton de modification.
        /// </summary>
        private Button btnModifierCegep;

        /// <summary>
        /// Méthode de service appelée lors de la création de l'activité.
        /// </summary>
        /// <param name="savedInstanceState">État de l'activité.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CegepModifier_Activity);

            edtNomCegepModifier = FindViewById<EditText>(Resource.Id.edtNomModifier);
            edtAdresseCegepModifier = FindViewById<EditText>(Resource.Id.edtAdresseModifier);
            edtVilleCegepModifier = FindViewById<EditText>(Resource.Id.edtVilleModifier);
            edtProvinceCegepModifier = FindViewById<EditText>(Resource.Id.edtProvinceModifier);
            edtCodePostalCegepModifier = FindViewById<EditText>(Resource.Id.edtCodePostalModifier);
            edtTelephoneCegepModifier = FindViewById<EditText>(Resource.Id.edtTelephoneModifier);
            edtCourrielCegepModifier = FindViewById<EditText>(Resource.Id.edtCourrielModifier);

            btnModifierCegep = FindViewById<Button>(Resource.Id.btnModifier);
            btnModifierCegep.Click += delegate
            {
                if((edtAdresseCegepModifier.Text.Length > 0) && (edtVilleCegepModifier.Text.Length >0 ) && (edtProvinceCegepModifier.Text.Length > 0) && (edtCodePostalCegepModifier.Text.Length > 0) && (edtTelephoneCegepModifier.Text.Length > 0) && (edtCourrielCegepModifier.Text.Length > 0))
                {
                    try
                    {
                        CegepControleur.Instance.ModifierCegep(new CegepDTO(paramNomCegep, edtAdresseCegepModifier.Text, edtVilleCegepModifier.Text, edtProvinceCegepModifier.Text, edtCodePostalCegepModifier.Text, edtTelephoneCegepModifier.Text, edtCourrielCegepModifier.Text));
                        DialoguesUtils.AfficherToasts(this, paramNomCegep + " modifié !!!");
                    }
                    catch (Exception ex)
                    {
                        DialoguesUtils.AfficherMessageOK(this, "Erreur", ex.Message);
                    }
                }
                else
                    DialoguesUtils.AfficherMessageOK(this, "Erreur", "Veuillez remplir tous les champs...");
            };

            paramNomCegep = Intent.GetStringExtra("paramNomCegep");
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
        /// Méthode permettant de rafraichir les informations du Cégep...
        /// </summary>
        private void RafraichirInterfaceDonnees()
        {
            try
            {
                leCegep = CegepControleur.Instance.ObtenirCegep(paramNomCegep);
                edtNomCegepModifier.Text = leCegep.Nom;
                edtAdresseCegepModifier.Text = leCegep.Adresse;
                edtVilleCegepModifier.Text = leCegep.Ville;
                edtProvinceCegepModifier.Text = leCegep.Province;
                edtCodePostalCegepModifier.Text = leCegep.CodePostal;
                edtTelephoneCegepModifier.Text = leCegep.Telephone;
                edtCourrielCegepModifier.Text = leCegep.Courriel;
            }
            catch (Exception)
            {
                Finish();
            }
        }

        /// <summary>Méthode de service permettant d'initialiser le menu de l'activité principale.</summary>
        /// <param name="menu">Le menu à construire.</param>
        /// <returns>Retourne True si l'optionMenu est bien créé.</returns>
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.CegepModifier_ActivityMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        /// <summary>Méthode de service permettant de capter l'évenement exécuté lors d'un choix dans le menu.</summary>
        /// <param name="item">L'item sélectionné.</param>
        /// <returns>Retourne si un option à été sélectionné avec succès.</returns>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.Retour:
                    Finish();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}