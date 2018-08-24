using Newtonsoft.Json.Linq;
using PInterestClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PInterestProject
{
    interface IApiActions
    {

        User GetUserInformation();
        List<UserBoard> GetUserBoard();
        List<UserBoard> GetBoardSuggestion();
        List<User> GetFollowerUsers();
        List<UserBoard> GetFollowingBoards();
        List<Interest> GetFollowingInterests();
        List<User> GetFollowingUsers();
        User GetUserAsync(string UserName);
        UserBoard SearchBoardsAsync(string query);
        IUserPin SearchPin(string pin);
        List<IUserPin> GetUserPins();
        object GetBoardSections(long board);
        object GetPinsBoardSection(long section);
        UserBoard GetBoard(long board);
        List<IUserPin> GetBoardPins(long board);
        IUserPin GetPins(long Pin);
        UserBoard CreateBoard(string name);
        string DeleteBoard(long board);
        object CreateBoardSection(long board, string title);
        string FollowBoard(long BoardId);
        string FollowUser(string userid);
        string UnfollowUser(string user);
        string UnfollowBoard(long BoardId);
        string DeleteBoardSection(long sectionid);
        string DeletePin(long pinid);
        IUserPin CreatePin(string BoardId, string note, string imageurl);
    }
  
}