using DataAccessLayer.EF;
using DataAccessLayer.Interfaces.AdmiInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    internal class TokenRepo : Repo, IAdmin<Token, string, Token>
    {
        public Token Add(Token obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public Token Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Token Get(string id)
        {
            return db.Tokens.FirstOrDefault(t => t.TKey == id);
        }

        public List<Token> GetAll()
        {
            throw new NotImplementedException();
        }

        public Token RemoveDepartment(string id)
        {
            throw new NotImplementedException();
        }

        public Token Update(Token obj)
        {
            var token = Get(obj.TKey);
            db.Entry(token).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return token;
            return null;
        }
    }
}
