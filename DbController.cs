using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using ExamProgram.Entity;

namespace ExamProgram
{
    class DbController
    {

        private static DbController _instance = null;
        private OleDbConnection _connection;
        private DbController()
        {
            try
            {
                _connection = new OleDbConnection();
                _connection.ConnectionString = Program.connectionString;
                //conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source," + ex);
            }

        }

        public static void SetInstance()
        {
            if (_instance != null)
            {
                _instance._connection.Close();
            }
            _instance = new DbController();
        }

        public static DbController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DbController();
            }
            return _instance;
        }

        private Boolean OpenConnection()
        {
            try
            {
                _connection.Open();
                //MessageBox.Show("connected successfuly");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        private Boolean CloseConnection()
        {
            try
            {
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public List<Question> GetQuestions()
        {
            List<Question> response = new List<Question>();
            try
            {
                this.OpenConnection();
                OleDbDataReader reader = null;  // This is OleDb Reader
                OleDbCommand cmd = new OleDbCommand(" select * from question ", _connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Question q = new Question();
                    q.qid = Int32.Parse(reader["QID"].ToString());
                    q.question = reader["Question"].ToString();
                    q.answer1 = reader["Answer1"].ToString();
                    q.answer2 = reader["Answer2"].ToString();
                    q.answer3 = reader["Answer3"].ToString();
                    q.answer4 = reader["Answer4"].ToString();
                    q.rightAnswer = Int32.Parse(reader["RightAnswer"].ToString());
                    q.groupId = Int32.Parse(reader["groupingID"].ToString());
                    response.Add(q);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            finally
            {
                this.CloseConnection();
            }
            return response;
        }

        public List<Question> GetQuestionsByGroupId(int groupId)
        {
            List<Question> response = new List<Question>();
            try
            {
                this.OpenConnection();
                OleDbDataReader reader = null;  // This is OleDb Reader
                OleDbCommand cmd = new OleDbCommand(" select * from question where groupingID = "+groupId, _connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Question q = new Question();
                    q.qid = Int32.Parse(reader["QID"].ToString());
                    q.question = reader["Question"].ToString();
                    q.answer1 = reader["Answer1"].ToString();
                    q.answer2 = reader["Answer2"].ToString();
                    q.answer3 = reader["Answer3"].ToString();
                    q.answer4 = reader["Answer4"].ToString();
                    q.rightAnswer = Int32.Parse(reader["RightAnswer"].ToString());
                    q.groupId = Int32.Parse(reader["groupingID"].ToString());
                    response.Add(q);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            finally
            {
                this.CloseConnection();
            }
            return response;
        }

        public List<General> GetGenerals()
        {
            List<General> response = new List<General>();
            try
            {
                this.OpenConnection();
                OleDbDataReader reader = null;  // This is OleDb Reader
                OleDbCommand cmd = new OleDbCommand(" SELECT general.[GeneralID], general.[GeneralName] FROM [general];", _connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    General g = new General();
                    g.generalId = Int32.Parse(reader["GeneralID"].ToString());
                    g.generalName = reader["GeneralName"].ToString();
                    response.Add(g);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            finally
            {
                this.CloseConnection();
            }
            return response;
        }

        public List<Grouping> GetGroups()
        {
            List<Grouping> response = new List<Grouping>();
            try
            {
                this.OpenConnection();
                OleDbDataReader reader = null;  // This is OleDb Reader
                OleDbCommand cmd = new OleDbCommand(" select * from grouping ", _connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Grouping g = new Grouping();
                    g.groupId = Int32.Parse(reader["groupingID"].ToString());
                    g.groupName = reader["groupingName"].ToString();
                    g.generalId = Int32.Parse(reader["GeneralID"].ToString());
                    response.Add(g);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            finally
            {
                this.CloseConnection();
            }
            return response;
        }
    }
}
