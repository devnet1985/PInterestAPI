using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PInterestClient.Models;
using PInterestProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PInterestClient
{

    public class ApiClient : IApiActions
    {
        private string _accessToken = string.Empty;

        private string _version = ApiVersion.V1;
        private HttpClient _httpClient = new HttpClient();
        private string _domain = "https://api.pinterest.com/";

        public ApiClient(string accesstoken)
        {

            this._accessToken = accesstoken;

        }

      

        #region ME
        /// <summary>
        /// Return the logged in user's information
        /// </summary>
        /// <returns></returns>


        public User GetUserInformation()
        {
            User user = new User();

            string fields = "id,username,first_name,last_name,url,created_at,counts,account_type,bio,image";
            JObject httpResponse = null;

            JObject payload = new JObject();
            httpResponse = this._httpClient.GetData(this._domain + _version + "/me/?fields=" + fields, "GET", this._accessToken);
            user = JsonConvert.DeserializeObject<User>(httpResponse["data"].ToString());
            return user;


        }
        /// <summary>
        /// Return the logged in user's Boards
        /// </summary>
        /// <returns></returns>

        public List<UserBoard> GetUserBoard()
        {
            List<UserBoard> userboard = new List<UserBoard>();
            string fields = "id,name,url,image,creator,created_at,counts,privacy,reason,description";
            JObject httpResponse = null;

            JObject payload = new JObject();
            httpResponse = this._httpClient.GetData(this._domain + _version + "/me/boards/?fields=" + fields, "GET", this._accessToken);
            userboard = (List<UserBoard>)Newtonsoft.Json.JsonConvert.DeserializeObject(httpResponse["data"].ToString(), typeof(List<UserBoard>));
            return userboard;
        }
        /// <summary>
        /// Return Board suggestions for the logged in user
        /// </summary>
        /// <returns></returns>
     
        public List<UserBoard> GetBoardSuggestion()
        {
            List<UserBoard> BoardSuggested = new List<UserBoard>();
            string fields = "id,name,url,image,creator,created_at,counts,privacy,reason,description";
            JObject httpResponse = null;

            JObject payload = new JObject();
            httpResponse = this._httpClient.GetData(this._domain + _version + "/me/boards/suggested/?fields=" + fields, "GET", this._accessToken);
            BoardSuggested = (List<UserBoard>)Newtonsoft.Json.JsonConvert.DeserializeObject(httpResponse["data"].ToString(), typeof(List<UserBoard>));
            return BoardSuggested;
        }

        /// <summary>
        /// Return the users that follow the logged in user
        /// </summary>
        /// <returns></returns>
       
        public List<User> GetFollowerUsers()
        {
            List<User> FollowUser = new List<User>();

            string fields = "id,username,first_name,last_name,url,created_at,counts,account_type,bio,image";
            JObject httpResponse = null;

            JObject payload = new JObject();
            httpResponse = this._httpClient.GetData(this._domain + _version + "/me/followers/?fields=" + fields, "GET", this._accessToken);
            FollowUser = (List<User>)Newtonsoft.Json.JsonConvert.DeserializeObject(httpResponse["data"].ToString(), typeof(List<User>));
            return FollowUser;
        }

        /// <summary>
        /// Get the Boards that the logged in user follows
        /// </summary>
        /// <returns></returns>
        /// 
     
        public List<UserBoard> GetFollowingBoards()
        {
            List<UserBoard> FollowUserBoard = new List<UserBoard>();
            string fields = "id,name,url,image,creator,created_at,counts,privacy,reason,description";
            JObject httpResponse = null;

            JObject payload = new JObject();
            httpResponse = this._httpClient.GetData(this._domain + _version + "/me/following/boards/?fields=" + fields, "GET", this._accessToken);
            FollowUserBoard = (List<UserBoard>)Newtonsoft.Json.JsonConvert.DeserializeObject(httpResponse["data"].ToString(), typeof(List<UserBoard>));
            return FollowUserBoard;
        }

        /// <summary>
        /// Return the Interests the logged in user follows
        /// </summary>
        /// <returns></returns>
        /// 
      
        public List<Interest> GetFollowingInterests()
        {
            List<Interest> FollowingInterest = new List<Interest>();
            string fields = "id,name";
            JObject httpResponse = null;

            JObject payload = new JObject();
            httpResponse = this._httpClient.GetData(this._domain + _version + "/me/following/interests/?fields=" + fields, "GET", this._accessToken);
            FollowingInterest = (List<Interest>)Newtonsoft.Json.JsonConvert.DeserializeObject(httpResponse["data"].ToString(), typeof(List<Interest>));
            return FollowingInterest;
        }
        /// <summary>
        /// Return the users that the logged in user follows
        /// </summary>
        /// <returns></returns>
        public List<User> GetFollowingUsers()
        {
            List<User> FollowingUser = new List<User>();

            string fields = "id,username,first_name,last_name,url,created_at,counts,account_type,bio,image";
            JObject httpResponse = null;

            JObject payload = new JObject();
            httpResponse = this._httpClient.GetData(this._domain + _version + "/me/following/users/?fields=" + fields, "GET", this._accessToken);
            FollowingUser = (List<User>)Newtonsoft.Json.JsonConvert.DeserializeObject(httpResponse["data"].ToString(), typeof(List<User>));
            return FollowingUser;
        }

        /// <summary>
        /// Return the logged in user's Pins
        /// </summary>
        /// <returns></returns>
        public List<IUserPin> GetUserPins()
        {
            List<IUserPin> UserPins = new List<IUserPin>();

            string fields = "id,url,created_at,counts,image,attribution,board,color,creator,link,media,metadata,note,original_link";
            JObject httpResponse = null;

            JObject payload = new JObject();
            httpResponse = this._httpClient.GetData(this._domain + _version + "/me/pins/?fields=" + fields, "GET", this._accessToken);
            UserPins = (List<IUserPin>)Newtonsoft.Json.JsonConvert.DeserializeObject(httpResponse["data"].ToString(), typeof(List<IUserPin>));
            return UserPins;
        }

        public IUserPin SearchPin(string pin)
        {
            IUserPin UserPins = new IUserPin();

            string fields = "id,url,created_at,counts,image,attribution,board,color,creator,link,media,metadata,note,original_link";
            JObject httpResponse = null;

            JObject payload = new JObject();
            httpResponse = this._httpClient.GetData(this._domain + _version + "/me/search/pins/?fields=" + fields + "&query=" + pin, "GET", this._accessToken);
            UserPins = JsonConvert.DeserializeObject<IUserPin>(httpResponse["data"].ToString());
            return UserPins;
        }

        /// <summary>
        /// Search the logged in user's Boards
        /// </summary>
        /// <returns></returns>
        public UserBoard SearchBoardsAsync(string query)
        {
            UserBoard SearchBoard = new UserBoard();
            string fields = "id,name,url,image,creator,created_at,counts,privacy,reason,description";
            JObject httpResponse = null;

            JObject payload = new JObject();
            httpResponse = this._httpClient.GetData(this._domain + _version + "/me/search/boards/?fields=" + fields + "&query=" + query, "GET", this._accessToken);
            SearchBoard = JsonConvert.DeserializeObject<UserBoard>(httpResponse["data"].ToString());
            return SearchBoard;
        }

        /// <summary>
        /// Follow a Board
        /// </summary>
        /// <param name="BoardId"></param>
        /// <returns></returns>
        /// 
        
        public string FollowBoard(long BoardId)
        {
            UserBoard boardcreate = new UserBoard();
            JObject httpResponse = null;
            JObject payload = new JObject();
            payload.Add(new JProperty("board",BoardId));
            httpResponse = this._httpClient.PostData(this._domain + _version + "/me/following/boards/?", "POST", payload.ToString(), this._accessToken);
            string response = "";
            CreateResponse Response = new CreateResponse();
            Response = JsonConvert.DeserializeObject<CreateResponse>(httpResponse.ToString());
            response = Response.StatusDescription;
            if (Response.StatusCode == 200)
            {
                return "Created Successfully";
            }

            else
            {

                return response;
            }
        }

        /// <summary>
        /// Unfollow a Board
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public string UnfollowBoard(long BoardId)
        {
    
            JObject httpResponse = null;
            string payload = "";
            DeleteResponse Respons = new DeleteResponse();
            httpResponse = this._httpClient.DeleteData(this._domain + _version + "/me/following/boards/"+ BoardId + "/?", "DELETE", this._accessToken);
            Respons = JsonConvert.DeserializeObject<DeleteResponse>(httpResponse.ToString());
            payload = Respons.data;

            if (payload == null)
            {
                return "Deleted Successfully";
            }
            else
            {
                return payload;
            }
            return payload;
        }
        /// <summary>
        /// Follow a user
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string FollowUser(string userid)
        {
          
            string response = "";
            JObject httpResponse = null;
            JObject payload = new JObject();
            CreateResponse Response = new CreateResponse();
            payload.Add(new JProperty("user", userid));
            httpResponse = this._httpClient.PostData(this._domain + _version + "/me/following/users/?", "POST", payload.ToString(), this._accessToken);
            Response = JsonConvert.DeserializeObject<CreateResponse>(httpResponse.ToString());
            response = Response.StatusDescription;
            if (Response.StatusCode== 200)
            {
                return "Created Successfully";
            }

            else
            {

                return response;
            }
            
           
        }

   

        /// <summary>
        /// Unfollow a user
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public string UnfollowUser(string user)
        {

            
            JObject httpResponse = null;
            DeleteResponse Respons = new DeleteResponse();
            string payload = "";
            httpResponse = this._httpClient.DeleteData(this._domain + _version + "/me/following/users/"+user+"/?", "DELETE", this._accessToken);
            Respons = JsonConvert.DeserializeObject<DeleteResponse>(httpResponse.ToString());
            payload = Respons.data;

            if (payload == null)
            {
                return "Deleted Successfully";
            }
            else
            {
                return payload;
            }
        }
        #endregion


        #region USER
        /// <summary>
        /// Return a user's information
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public User GetUserAsync(string UserName)
        {
            User user = new User();

            string fields = "id,username,first_name,last_name,url,created_at,counts,account_type,bio,image";
            JObject httpResponse = null;

            JObject payload = new JObject();
            httpResponse = this._httpClient.GetData(this._domain + _version + "/users/" + UserName + "/?fields=" + fields, "GET", this._accessToken);
            user = JsonConvert.DeserializeObject<User>(httpResponse["data"].ToString());
            return user;


        }


        #endregion


        #region BOARD
        /// <summary>
        /// Gets sections for a board.
        /// </summary>
        /// <returns></returns>
        public object GetBoardSections(long board)
        {
            object boardsection = new object();
            JObject httpResponse = null;

            httpResponse = this._httpClient.GetData(this._domain + _version + "/board/" + board + "/sections/?", "GET", this._accessToken);
            boardsection = JsonConvert.DeserializeObject<object>(httpResponse["data"].ToString());
            return boardsection;
        }

        /// <summary>
        /// Creates a new board section
        /// </summary>
        /// <param name="board"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public object CreateBoardSection(long board,string title)
        {
            object boardsection = new object();
            JObject httpResponse = null;
            JObject payload = new JObject();
            payload.Add(new JProperty("title", title));
            httpResponse = this._httpClient.PutData(this._domain + _version + "/board/" + board + "/sections/?", "PUT",payload.ToString(), this._accessToken);
            boardsection = JsonConvert.DeserializeObject<object>(httpResponse["StatusCode"].ToString());
            return boardsection;
        }

        /// <summary>
        /// Gets the pins for a board section.
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>

        public object GetPinsBoardSection(long section)
        {
            object boardPins = new object();
            JObject httpResponse = null;

            JObject payload = new JObject();
            httpResponse = this._httpClient.GetData(this._domain + _version + "/board/sections/" + section + "/pins/?", "GET", this._accessToken);
            boardPins = JsonConvert.DeserializeObject<object>(httpResponse["data"].ToString());
            return boardPins;
        }
        /// <summary>
        /// Deletes a board section.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public string DeleteBoardSection(long sectionid)
        {

            JObject httpResponse = null;
            string payload = "";
            DeleteResponse Respons = new DeleteResponse();
            httpResponse = this._httpClient.DeleteData(this._domain + _version + "/board/sections/"+ sectionid + "/?", "DELETE", this._accessToken);
            Respons = JsonConvert.DeserializeObject<DeleteResponse>(httpResponse.ToString());
            payload = Respons.data;

            if (payload == null)
            {
                return "Deleted Successfully";
            }
            else
            {
                return payload;
            }
        }

        #endregion

        #region BOARDS

        public UserBoard GetBoard(long board)
        {
            UserBoard userboard = new UserBoard();
            string fields = "id,name,url,image,creator,created_at,counts,privacy,reason,description";
            JObject httpResponse = null;

            JObject payload = new JObject();
            httpResponse = this._httpClient.GetData(this._domain + _version + "/boards/"+ board + "/?fields=" + fields, "GET", this._accessToken);
            userboard = JsonConvert.DeserializeObject<UserBoard>(httpResponse["data"].ToString());
            return userboard;
        }

        public List<IUserPin> GetBoardPins(long board)
        {
            List<IUserPin> BoardSuggested = new List<IUserPin>();
            string fields = "id,url,created_at,counts,image,attribution,board,color,creator,link,media,metadata,note,original_link";
            JObject httpResponse = null;
            httpResponse = this._httpClient.GetData(this._domain + _version + "/boards/"+ board + "/pins/?fields=" + fields, "GET", this._accessToken);
            BoardSuggested = (List<IUserPin>)Newtonsoft.Json.JsonConvert.DeserializeObject(httpResponse["data"].ToString(), typeof(List<IUserPin>));
            return BoardSuggested;
        }



        /// <summary>
        /// Create a Board
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public UserBoard CreateBoard(string name)
        {
            UserBoard boardcreate = new UserBoard();
            JObject httpResponse = null;
            JObject payload = new JObject();
            payload.Add(new JProperty("name", name));
            httpResponse = this._httpClient.PostData(this._domain + _version + "/boards/?", "POST", payload.ToString(), this._accessToken);
            string response = "";
            CreateResponse Response = new CreateResponse();
            boardcreate = JsonConvert.DeserializeObject<UserBoard>(httpResponse["data"].ToString());
            return boardcreate;
        }

        

        /// <summary>
        /// Delete a Board
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public string DeleteBoard(long board)
        {
          
            
            JObject httpResponse = null;
            DeleteResponse Respons = new DeleteResponse();
            string payload = "";
            httpResponse = this._httpClient.DeleteData(this._domain + _version + "/boards/" + board + "/?", "DELETE", this._accessToken);
            Respons = JsonConvert.DeserializeObject<DeleteResponse>(httpResponse.ToString());
            payload  = Respons.data;

            if(payload==null)
            {
                return "Deleted Successfully";
            }
            else
            {
                return payload;
            }

            //payload = JsonConvert.DeserializeObject<Respons>(Respons.ToString());

           
        }
        /// <summary>
        /// Edit a Board
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        public UserBoard EditBoard(long boardid,string boardname, string boarddescription)
        {
            UserBoard boardcreate = new UserBoard();
            JObject httpResponse = null;
            JObject payload = new JObject();
            payload.Add(new JProperty("name", boardname));
            payload.Add(new JProperty("description", boarddescription));
            httpResponse = this._httpClient.UpdateData(this._domain + _version + "/boards/"+ boardid +"/? ", "PATCH", payload.ToString(), this._accessToken);
            boardcreate = JsonConvert.DeserializeObject<UserBoard>(httpResponse["data"].ToString());
            return boardcreate;
        }
        #endregion


        #region PINS
        public IUserPin GetPins(long Pin)
        {
           IUserPin pins = new IUserPin();
            string fields = "id,url,created_at,counts,image,attribution,board,color,creator,link,media,metadata,note,original_link";
            JObject httpResponse = null;
            httpResponse = this._httpClient.GetData(this._domain + _version + "/pins/"+Pin+"/?fields=" + fields, "GET", this._accessToken);
            pins = JsonConvert.DeserializeObject<IUserPin>(httpResponse["data"].ToString());
            return pins;
        }



        /// <summary>
        /// Delete a Pin
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public string DeletePin(long pinid)
        {

            JObject httpResponse = null;
            string payload = "";
            DeleteResponse Respons = new DeleteResponse();
            httpResponse = this._httpClient.DeleteData(this._domain + _version + "/pins/"+pinid+"/?", "DELETE", this._accessToken);
            payload = JsonConvert.DeserializeObject<string>(httpResponse["data"].ToString());
            Respons = JsonConvert.DeserializeObject<DeleteResponse>(httpResponse["data"].ToString());
            payload = Respons.data;

            if (payload == null)
            {
                return "Deleted Successfully";
            }
            else
            {
                return payload;
            }
        }



        /// <summary>
        /// Create Pin
        /// </summary>
        /// <param name="BoardId"></param>
        /// <returns></returns>

        public IUserPin CreatePin(string BoardId, string note, string imageurl)
        {
   
            string fields = "id,url,created_at,counts,image,attribution,board,color,creator,link,media,metadata,note,original_link";
            JObject httpResponse = null;
            JObject payload = new JObject();
            payload.Add(new JProperty("board", BoardId));
            payload.Add(new JProperty("note", note));
            payload.Add(new JProperty("image_url", imageurl));
            httpResponse = this._httpClient.PostData(this._domain + _version + "/pins/?fields="+ fields, "POST", payload.ToString(), this._accessToken);
            IUserPin Response = new IUserPin();
            Response = JsonConvert.DeserializeObject<IUserPin>(httpResponse["data"].ToString());
            return Response;
            
        }

        public string EditPin(long pin, long board, string note, string link)
        {
            object boardcreate = new object();
          
            JObject httpResponse = null;
            JObject payload = new JObject();
            payload.Add(new JProperty("pin", pin));
            payload.Add(new JProperty("board", board));
            payload.Add(new JProperty("link", link));
            payload.Add(new JProperty("note", note));
            httpResponse = this._httpClient.UpdateData(this._domain + _version + "/pins/"+pin+"/? ", "PATCH", payload.ToString(), this._accessToken);
            boardcreate = JsonConvert.DeserializeObject<object>(httpResponse["data"].ToString());
            return "";
        }
        #endregion


    }
}
