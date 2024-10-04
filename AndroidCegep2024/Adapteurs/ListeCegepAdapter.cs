using Android.Views;
using AndroidCegep2024.DTOs;

/// <summary>
/// Namespace pour les adapteurs.
/// </summary>
namespace AndroidCegep2024.Adapters
{
    /// <summary>
    /// Classe représentant un adapteur pour une liste de Cégep(s).
    /// </summary>
    public class ListeCegepAdapter : BaseAdapter<CegepDTO>
    {
        /// <summary>
        /// Attribut représetant le contexte.
        /// </summary>
		private Activity context;
        /// <summary>
        /// Attribut représentant la liste de Cegeps.
        /// </summary>
		private CegepDTO[] listeCegep;

        /// <summary>
        /// Constructeur de la classe. 
        /// </summary>
        /// <param name="context">Contexte.</param>
        /// <param name="acteurs">Liste des Cégeps.</param>
		public ListeCegepAdapter(Activity unContext, CegepDTO[] uneListeCegep)
        {
            context = unContext;
            listeCegep = uneListeCegep;
        }

        /// <summary>
        /// Méthode réécrite de la classe BaseAdapter permettant d'accéder à un élément de la liste de Cégeps selon un index.
        /// </summary>
        /// <param name="index">Index de la garderie.</param>
        /// <returns>Retourne un CegepDTO contenant les informations du Cégep selon l'index passé en paramètre.</returns>
		public override CegepDTO this[int index]
        {
            get { return listeCegep[index]; }
        }

        /// <summary>
        /// Méthode réécrite de la classe BaseAdapter permettant d'obtenir le Id d'un Cégep selon une position.
        /// </summary>
        /// <param name="position">Position du Cégep.</param>
        /// <returns>Retourne le ID du Cégep à la position demandée.</returns>
		public override long GetItemId(int position)
        {
            return position;
        }

        /// <summary>
        /// Méthode réécrite de la classe BaseAdapter permettant d'obtenir le nombre de Cégep(s) dans la liste.
        /// </summary>
        /// <returns>Retourne le nombre de Cégep(s) dans la liste.</returns>
		public override int Count
        {
            get { return listeCegep.Length; }
        }

        /// <summary>
        /// Méthode réécrite de la classe BaseAdapter permettant d'obtenir le visuel d'un Cégep.
        /// </summary>
        /// <param name="position">Position du Cégep.</param>
        /// <param name="convertView">Vue.</param>
        /// <param name="parent">Parent de la vue.</param>
        /// <returns>Retourne une vue construite avec les données d'un Cégep.</returns>
		public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view =
                (convertView ??
                   context.LayoutInflater.Inflate(
                        Resource.Layout.ListeCegepItem, parent, false)) as LinearLayout;

            view.FindViewById<TextView>(Resource.Id.tvNomCegep).Text = listeCegep[position].Nom;

            return view;
        }
    }
}