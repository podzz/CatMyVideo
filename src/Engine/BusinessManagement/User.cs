﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Engine.BusinessManagement
{
    public static class User
    {
        public static IList<Dbo.User> ListClassicUsers(Dbo.User.Order order = Dbo.User.Order.Id, bool ascOrder = true, int number = -1, int page = -1)
        {
            try
            {
                return DataAccess.User.ListClassics(order, ascOrder, number, page);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static IList<Dbo.User> ListAdminUsers(Dbo.User.Order order = Dbo.User.Order.Id, bool ascOrder = true, int number = -1, int page = -1)
        {
            try
            {
                return DataAccess.User.ListAdmins(order, ascOrder, number, page);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static IList<Dbo.User> ListModoUsers(Dbo.User.Order order = Dbo.User.Order.Id, bool ascOrder = true, int number = -1, int page = -1)
        {
            try
            {
                return DataAccess.User.ListModerators(order, ascOrder, number, page);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static IList<Dbo.User> ListAllUsers(Dbo.User.Order order = Dbo.User.Order.Id, bool ascOrder = true, int number = -1, int page = -1)
        {
            try
            {
                return ListClassicUsers().Concat(ListModoUsers()).Concat(ListAdminUsers()).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void AddUser(Dbo.User user)
        {
            try
            {
                DataAccess.User.AddUser(user);
            }
            catch (Exception)
            {
                throw new Exception("Can't add user (" + user.ToString() + ")");
            }
        }

        public static void UpdateUser(Dbo.User user)
        {
            try
            {
                DataAccess.User.UpdateUser(user);
            }
            catch (Exception)
            {
                throw new Exception("Can't update user (" + user.ToString() + ")");
            }
        }

        public static void DeleteUser(int id)
        {
            try
            {
                DataAccess.User.DeleteUser(id);
            }
            catch (Exception)
            {
                throw new Exception("Can't delete user (" + id + ")");
            }
        }

        public static Dbo.User FindUser(int id)
        {
            try
            {
                return DataAccess.User.FindUserById(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Dbo.User FindUser(string email)
        {
            try
            {
                return DataAccess.User.FindUserByEmail(email);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}