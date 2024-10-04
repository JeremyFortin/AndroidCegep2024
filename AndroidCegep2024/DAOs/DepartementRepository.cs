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
    /// Classe représentant le répository d'un département.
    /// </summary>
    public class DepartementRepository : Repository
    {
        #region AttributsProprietes

        /// <summary>
        /// Instance unique du repository.
        /// </summary>
        private static DepartementRepository instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static DepartementRepository Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new DepartementRepository();
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
        private DepartementRepository() :base() {}

        #endregion

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir le ID d'un département selon ses informatiques uniques.
        /// </summary>
        /// <param name="nomCegep">Le nom du Cégep.</param>
        /// <param name="nomDepartement">Le nom du Cégep.</param>
        /// <returns>Le ID du département.</returns>
        public int ObtenirIdDepartement(string nomCegep, string nomDepartement)
        {
            SqlCommand command = new SqlCommand(" SELECT Id " +
                                                "   FROM Departements " +
                                                "  WHERE Nom = @nom " +
                                                "    AND IdCegep = @idCegep", connexion);

            SqlParameter nomDepartementParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            SqlParameter idCegepParam = new SqlParameter("@idCegep", SqlDbType.Int);

            nomDepartementParam.Value = nomDepartement;
            idCegepParam.Value = CegepRepository.Instance.ObtenirIdCegep(nomCegep);

            command.Parameters.Add(nomDepartementParam);
            command.Parameters.Add(idCegepParam);

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
                throw new Exception("Erreur lors de l'obtention d'un id d'un département par son nom et son Cégep...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des départements d'un Cégep.
        /// </summary>
        /// <param name="nomCegep">Le nom du Cégep.</param>
        /// <returns>Liste des départements.</returns>
        public List<DepartementDTO> ObtenirListeDepartement(string nomCegep)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM Departements " +
                                                "  WHERE IdCegep = @idCegep", connexion);

            SqlParameter idCegepParam = new SqlParameter("@idCegep", SqlDbType.Int);

            idCegepParam.Value = CegepRepository.Instance.ObtenirIdCegep(nomCegep);

            command.Parameters.Add(idCegepParam);

            List<DepartementDTO> liste = new List<DepartementDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    DepartementDTO departement = new DepartementDTO(reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    liste.Add(departement);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention de la liste des départements par le nom du Cégep...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un département selon ses informations uniques.
        /// </summary>
        /// <param name="nomCegep">Nom du Cégep.</param>
        /// <param name="nomCegep">Nom du département.</param>
        /// <returns>Le DTO du département.</returns>
        public DepartementDTO ObtenirDepartement(string nomCegep, string nomDepartement)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM Departements " +
                                                " WHERE nom = @nom " +
                                                "   AND IdCegep = @idCegep", connexion);

            SqlParameter nomDepartementParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            SqlParameter idCegepParam = new SqlParameter("@idCegep", SqlDbType.Int);

            nomDepartementParam.Value = nomDepartement;
            idCegepParam.Value = CegepRepository.Instance.ObtenirIdCegep(nomCegep);

            command.Parameters.Add(nomDepartementParam);
            command.Parameters.Add(idCegepParam);

            DepartementDTO unDepartement;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                unDepartement = new DepartementDTO(reader.GetString(1), reader.GetString(2), reader.GetString(3));
                reader.Close();
            return unDepartement;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'un département par son nom et son cégep...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un département.
        /// </summary>
        /// <param name="nomCegep">Le nom du Cégep.</param>
        /// <param name="departementDTO">Le DTO du departement.</param>
        public void AjouterDepartement(string nomCegep, DepartementDTO departementDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " INSERT INTO Departements (No, Nom, Description, idCegep) " +
                                  " VALUES (@no, @nom, @description, @idCegep) ";

            SqlParameter noParam = new SqlParameter("@no", SqlDbType.VarChar, 10);
            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            SqlParameter descriptionParam = new SqlParameter("@description", SqlDbType.VarChar, 100);
            SqlParameter idCegepParam = new SqlParameter("@idCegep", SqlDbType.Int);

            noParam.Value = departementDTO.No;
            nomParam.Value = departementDTO.Nom;
            descriptionParam.Value = departementDTO.Description;
            idCegepParam.Value = CegepRepository.Instance.ObtenirIdCegep(nomCegep);

            command.Parameters.Add(noParam);
            command.Parameters.Add(nomParam);
            command.Parameters.Add(descriptionParam);
            command.Parameters.Add(idCegepParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBUniqueException("Erreur lors de l'ajout d'un département...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de modifier un département.
        /// </summary>
        /// <param name="nomCegep">Le nom du Cégep.</param>
        /// <param name="departementDTO">Le DTO du département.</param>
        public void ModifierDepartement(string nomCegep, DepartementDTO departementDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " UPDATE Departements " +
                                     " SET No = @no, " +
                                     "     Description = @description " +
                                   " WHERE Nom = @nom " +
                                   "   AND idCegep = @idCegep ";

            SqlParameter noParam = new SqlParameter("@no", SqlDbType.VarChar, 10);
            SqlParameter descriptionParam = new SqlParameter("@description", SqlDbType.VarChar, 100);
            SqlParameter idCegepParam = new SqlParameter("@idCegep", SqlDbType.Int);

            noParam.Value = departementDTO.No;
            descriptionParam.Value = departementDTO.Description;
            idCegepParam.Value = CegepRepository.Instance.ObtenirIdCegep(nomCegep);

            command.Parameters.Add(noParam);
            command.Parameters.Add(descriptionParam);
            command.Parameters.Add(idCegepParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la modification d'un département...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de supprimer un département.
        /// </summary>
        /// <param name="nomCegep">Le nom du Cégep.</param>
        /// <param name="departementDTO">Le DTO du département.</param>
        public void SupprimerDepartement(string nomCegep, DepartementDTO departementDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE " +
                                    " FROM Departements " +
                                   " WHERE Id = @id ";

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);

            idParam.Value = ObtenirIdDepartement(nomCegep, departementDTO.Nom);

            command.Parameters.Add(idParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'un département...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        #endregion
    }
}
