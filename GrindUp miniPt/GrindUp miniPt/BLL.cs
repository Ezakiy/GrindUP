using DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class BLL
    {
      

        public class Clientes
        {


            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("select * from Clientes", null);
            }
            static public DataTable LoadNomeIdCliente()
            {
                DAL dal = new DAL();
                return dal.executarReader("select Id,Nome,mensalidade,Inativo from Clientes", null);
            }
            static public DataTable queryLogin(string Nome, string Senha)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Nome", Nome),
                 new SqlParameter("@Senha", Senha)

                };
                return dal.executarReader("select * from Clientes where Nome=@Nome and Senha=@Senha and inativo = 0", sqlParams);
            }
            static public int insertCliente(string Nome, string Telefone, string Morada, string Email, byte[] Foto, int Peso, int Altura, string Genero, string Senha, string NIF, DateTime data_nasc, string mensalidade)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Nome", Nome),      
                new SqlParameter("@Telefone", Telefone),
                new SqlParameter("@Morada", Morada),
                new SqlParameter("@Email", Email),
                new SqlParameter("@Foto", Foto),
                new SqlParameter("@Peso", Peso),
                new SqlParameter("@Altura", Altura),
                new SqlParameter("@Genero", Genero),
                new SqlParameter("@Senha", Senha),
              //new SqlParameter("@Inativo", Inativo),
                new SqlParameter("@NIF", NIF),
                new SqlParameter("@data_nasc", data_nasc),
                 new SqlParameter("@mensalidade", mensalidade)

           };

                return dal.executarNonQuery("INSERT into Clientes (Nome,Telefone,Morada,Email,Foto,Peso,Altura,Genero,Senha,NIF,data_nasc,mensalidade,inativo) VALUES(@Nome,@Telefone,@Morada,@Email,@Foto,@Peso,@Altura,@Genero,@Senha,@NIF,@data_nasc,@mensalidade, 0)", sqlParams);
            }

            static public int deleteCliente(int Id)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Id", Id),

            };
                return dal.executarNonQuery("Delete From Clientes WHERE[Id]=@Id", sqlParams);
            }
            static public DataTable queryCliente_Like(String nome)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@nome", nome + "%")
                };
                return dal.executarReader("select * from Clientes where Nome like @nome", sqlParams);
            }

            static public DataTable queryCliente(int id)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id)
                };
                return dal.executarReader("select * from Clientes where ID=@id", sqlParams);
            }

            static public DataTable queryCliente_2(int id, string nome)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),
                 new SqlParameter("@Nome", nome)
                };
                return dal.executarReader("select * from Clientes where ID=@id and Nome=@nome", sqlParams);
            }

            static public DataTable queryCliente_3(int id)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id)
                };
                return dal.executarReader("select * from Clientes where ID=@id", sqlParams);
            }

            static public int updateClienteInativo(int id, bool Inativo /*string Nome, string Telefone, string Morada, string Email, byte[] Foto, int Peso, int Altura, string Genero, string Senha, int NIF, DateTime data_nasc, string mensalidade*/)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),
                new SqlParameter("@Inativo", Inativo)
                //new SqlParameter("@Nome", Nome),      
                //new SqlParameter("@Telefone", Telefone),
                //new SqlParameter("@Morada", Morada),
                //new SqlParameter("@Email", Email),
                //new SqlParameter("@Foto", Foto),
                //new SqlParameter("@Peso", Peso),
                //new SqlParameter("@Altura", Altura),
                //new SqlParameter("@Genero", Genero),
                //new SqlParameter("@Senha", Senha),     
                //new SqlParameter("@NIF", NIF),
                //new SqlParameter("@data_nasc", data_nasc),
                //new SqlParameter("@mensalidade", mensalidade),
             

            };
                return dal.executarNonQuery("update [Clientes] set Inativo = 1 where id=@id", sqlParams);
            }

            static public int updateCliente(int id, string Nome, string Telefone, string Morada, string Email, int Peso, int Altura, string Genero, string Senha, int NIF, DateTime data_nasc, string mensalidade)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),
                new SqlParameter("@Nome", Nome),      
                new SqlParameter("@Telefone", Telefone),
                new SqlParameter("@Morada", Morada),
                new SqlParameter("@Email", Email),
                new SqlParameter("@Peso", Peso),
                new SqlParameter("@Altura", Altura),
                new SqlParameter("@Genero", Genero),
                new SqlParameter("@Senha", Senha),     
                new SqlParameter("@NIF", NIF),
                new SqlParameter("@data_nasc", data_nasc),
                new SqlParameter("@mensalidade", mensalidade),
             

            };
                return dal.executarNonQuery("update [Clientes] set [Nome]=@Nome, [Telefone]=@Telefone, [Morada]=@Morada, [Peso]=@Peso, [Altura]=@Altura, [Genero]=@Genero, [Senha]=@Senha, [NIF]=@NIF, [data_nasc]=@data_nasc, [mensalidade]=@mensalidade where id=@id", sqlParams);
            }

            static public int alterarPerfil(string utilizador, String password, string imagem)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@utilizador", utilizador),
                    new SqlParameter("@password", password),
                    new SqlParameter("@imagem", imagem)};

                return dal.executarNonQuery("update [utilizadores] set [password]=@password, [imagem]=@imagem where [utilizador]=@utilizador", sqlparams);
            }

            static public int alterarEstado(string utilizador, int estado)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@utilizador", utilizador),
                    new SqlParameter("@estado", estado)};

                return dal.executarNonQuery("update utilizadores set estado=@estado where utilizador=@utilizador", sqlparams);
            }

        }

        public class Horario
        {
            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("select * from Horario", null);
            }
            static public DataTable LoadHorarioAdmin()
            {
                DAL dal = new DAL();
                return dal.executarReader("select id, aula from Horario", null);
            }
            static public DataTable LoadInscricoes()
            {
                DAL dal = new DAL();
                return dal.executarReader("select Id from Inscrições", null);
            }
            static public DataTable queryHorario(int id)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id)
                };
                return dal.executarReader("select * from Horario where id=@id ", sqlParams);
            }
            static public int insertHorario(int id_aula)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id_aula",id_aula)
                };
                return dal.executarNonQuery("INSERT into Clientes (id_aula) VALUES(@id_aula)", sqlParams);
            }
            
            static public object queryLotacao(string id)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id)
                };
                return dal.executarScalar("select lotacao from Horario where id=@id ", sqlParams);
            }
            static public object queryInscricoes(string id_horario)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id_horario", id_horario)
                };
                return dal.executarScalar("select count(id_horario) from Inscrições where id_horario=@id_horario ", sqlParams);
            }
        }

        public class Funcionário
        {
            static public DataTable queryLoginFuncionário(string Nome, string Senha)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Nome", Nome),
                 new SqlParameter("@Senha", Senha),
                };
                return dal.executarReader("select * from Funcionário where Nome=@Nome and Senha=@Senha", sqlParams);
            }
            static public DataTable queryLoginAdmin(string Nome, string Senha, bool Admin)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Nome", Nome),
                 new SqlParameter("@Senha", Senha),
                  new SqlParameter("@Admin", Admin),
                };
                return dal.executarReader("select * from Funcionário where Nome=@Nome, Senha=@Senha and Admin=@Admin", sqlParams);
            }
            static public int insertFuncionário(string Nome, string Funções, string Senha, bool admin)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Nome", Nome),
                new SqlParameter("@Funções", Funções),
                new SqlParameter("@Senha", Senha),
                          new SqlParameter("@admin", admin),
           };

                return dal.executarNonQuery("INSERT into Funcionário (Nome,Funções,Senha, admin) VALUES(@Nome,@Funções,@Senha,@admin)", sqlParams);
            }
            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("select * from Funcionário", null);
            }
            static public int deleteFuncionário(int IdFunc)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@IdFunc", IdFunc),

            };
                return dal.executarNonQuery("Delete From Funcionário WHERE[IdFunc]=@IdFunc", sqlParams);
            }
            static public int LoginTreinador(int IdFunc)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@IdFunc", IdFunc),

            };
                return dal.executarNonQuery("Select Nome From Funcionário WHERE Funções=@Treinador", sqlParams);
            }
        }

        public class inscricao
        {
            static public int insertInscrição( int id_cliente, int id_horario)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                 new SqlParameter("@id_cliente",id_cliente),
                    new SqlParameter("@id_horario",id_horario),

                };
                return dal.executarNonQuery("INSERT into Inscrições (id_cliente, id_horario ) VALUES(@id_cliente ,@id_horario)", sqlParams);
            }
            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("select * from Inscrições", null);
            }
            static public int deleteInscricao(int ID_cliente)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@ID_cliente", ID_cliente),

            };
                return dal.executarNonQuery("Delete From Inscrições WHERE[ID_cliente]=@ID_cliente", sqlParams);
            }
        }

        public class Presenca
        {
            static public DataTable Load()
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]
                {

                };
                return dal.executarReader("select Inscrições.Id, Clientes.nome, Horario.aula from (Horario inner join Inscrições on Horario.id = Inscrições.id_horario) inner join Clientes on Inscrições.ID_cliente = Clientes.Id", null);
            }

            static public int insertPresenca(int id_inscricao, bool presente, DateTime data)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                 new SqlParameter("@id_inscricao",id_inscricao),
                    new SqlParameter("@presente",presente),
                    new SqlParameter("@data",data),



                };
                return dal.executarNonQuery("INSERT into Presenca (id_inscricao, presente, data ) VALUES(@id_inscricao,@presente,@data)", sqlParams);
            }
        }

        public class VerPresenças
        {
            static public DataTable Load()
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]
                {

                };
                return dal.executarReader("select * from Presenca", null);
            }
        }
       
        
    
    
    
    }
    



}