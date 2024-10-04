using Microsoft.Data.SqlClient;
using System.Data;
using AndroidCegep2024.DTOs;
using AndroidCegep2024.Exceptions;

/// <summary>
/// Namespace pour les classe de type DAO.
/// </summary>
namespace AndroidCegep2024.DAOs
{
    /// <summary>
    /// Classe représentant le répository d'un cégep.
    /// </summary>
    public class CegepRepository : Repository
    {
        #region AttributsProprietes

        /// <summary>
        /// Instance unique du repository.
        /// </summary>
        private static CegepRepository instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static CegepRepository Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new CegepRepository();
                }
                //...on retourne l'instance unique.
                return instance;
            }
        }

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur privée du repository.
        /// </summary>
        private CegepRepository() :base() {}

        #endregion

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir le ID d'un cégep selon ses informatiques uniques.
        /// </summary>
        /// <param name="nom">Le titre du Cégep.</param>
        /// <returns>Le ID du Cégep.</returns>
        public int ObtenirIdCegep(string nom)
        {
            SqlCommand command = new SqlCommand(" SELECT Id " +
                                                "   FROM Cegeps " +
                                                "  WHERE Nom = @nom ", connexion);

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);

            nomParam.Value = nom;

            command.Parameters.Add(nomParam);

            int id;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                id = reader.GetInt32(0);
                reader.Close();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'un id d'un Cégep par son nom...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des départements d'un Cégep.
        /// </summary>
        /// <returns>Liste des départements.</returns>
        public List<CegepDTO> ObtenirListeCegep()
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM Cegeps ", connexion);

            List<CegepDTO> liste = new List<CegepDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CegepDTO cegep = new CegepDTO(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                    liste.Add(cegep);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un Cégep selon ses informations uniques.
        /// </summary>
        /// <param name="nom">Nom du Cégep.</param>
        /// <returns>Le DTO du Cégep.</returns>
        public CegepDTO ObtenirCegep(string nom)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM Cegeps " +
                                                " WHERE nom = @nom ", connexion);

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);

            nomParam.Value = nom;

            command.Parameters.Add(nomParam);

            CegepDTO unCegep;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                unCegep = new CegepDTO(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                reader.Close();
            return unCegep;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'un Cégep par son nom...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un Cégep.
        /// </summary>
        /// <param name="cegepDTO">Le DTO du cegep.</param>
        public void AjouterCegep(CegepDTO cegepDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " INSERT INTO Cegeps (Nom, Adresse, Ville, Province, CodePostal, Telephone, Courriel) " +
                                  " VALUES (@nom, @adresse, @ville, @province, @codePostal, @telephone, @courriel) ";

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            SqlParameter adresseParam = new SqlParameter("@adresse", SqlDbType.VarChar, 100);
            SqlParameter villeParam = new SqlParameter("@ville", SqlDbType.VarChar, 75);
            SqlParameter provinceParam = new SqlParameter("@province", SqlDbType.VarChar, 50);
            SqlParameter codePostalParam = new SqlParameter("@codePostal", SqlDbType.VarChar, 7);
            SqlParameter telephoneParam = new SqlParameter("@telephone", SqlDbType.VarChar, 12);
            SqlParameter courrielParam = new SqlParameter("@courriel", SqlDbType.VarChar, 100);

            nomParam.Value = cegepDTO.Nom;
            adresseParam.Value = cegepDTO.Adresse;
            villeParam.Value = cegepDTO.Ville;
            provinceParam.Value = cegepDTO.Province;
            codePostalParam.Value = cegepDTO.CodePostal;
            telephoneParam.Value = cegepDTO.Telephone;
            courrielParam.Value = cegepDTO.Courriel;

            command.Parameters.Add(nomParam);
            command.Parameters.Add(adresseParam);
            command.Parameters.Add(villeParam);
            command.Parameters.Add(provinceParam);
            command.Parameters.Add(codePostalParam);
            command.Parameters.Add(telephoneParam);
            command.Parameters.Add(courrielParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBUniqueException("Erreur lors de l'ajout d'un cégep...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de modifier un Cégep.
        /// </summary>
        /// <param name="cegepDTO">Le DTO du Cégep.</param>
        public void ModifierCegep(CegepDTO cegepDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " UPDATE Cegeps " +
                                     " SET Adresse = @adresse, " +
                                     "     Ville = @ville, " +
                                     "     Province = @province, " +
                                     "     CodePostal = @codePostal, " +
                                     "     Telephone = @telephone, " +
                                     "     Courriel = @courriel " +
                                   " WHERE Nom = @nom ";

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            SqlParameter adresseParam = new SqlParameter("@adresse", SqlDbType.VarChar, 100);
            SqlParameter villeParam = new SqlParameter("@ville", SqlDbType.VarChar, 75);
            SqlParameter provinceParam = new SqlParameter("@province", SqlDbType.VarChar, 50);
            SqlParameter codePostalParam = new SqlParameter("@codePostal", SqlDbType.VarChar, 7);
            SqlParameter telephoneParam = new SqlParameter("@telephone", SqlDbType.VarChar, 12);
            SqlParameter courrielParam = new SqlParameter("@courriel", SqlDbType.VarChar, 100);

            nomParam.Value = cegepDTO.Nom;
            adresseParam.Value = cegepDTO.Adresse;
            villeParam.Value = cegepDTO.Ville;
            provinceParam.Value = cegepDTO.Province;
            codePostalParam.Value = cegepDTO.CodePostal;
            telephoneParam.Value = cegepDTO.Telephone;
            courrielParam.Value = cegepDTO.Courriel;

            command.Parameters.Add(nomParam);
            command.Parameters.Add(adresseParam);
            command.Parameters.Add(villeParam);
            command.Parameters.Add(provinceParam);
            command.Parameters.Add(codePostalParam);
            command.Parameters.Add(telephoneParam);
            command.Parameters.Add(courrielParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la modification d'un Cégep...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de supprimer un Cégep.
        /// </summary>
        /// <param name="cegepDTO">Le DTO du Cégep.</param>
        public void SupprimerCegep(CegepDTO cegepDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE " +
                                    " FROM Cegeps " +
                                   " WHERE Id = @id ";

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);

            idParam.Value = ObtenirIdCegep(cegepDTO.Nom);

            command.Parameters.Add(idParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'un Cégep...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        #endregion
    }
}
