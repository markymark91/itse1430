using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public abstract class CharacterRoster : ICharacterRoster
    {
        public Character Add (Character character)
        {
            if (character == null)
                return null;

            var results = ObjectValidator.TryValidateObject (character);
            if (results.Count () > 0)
                return null;

            var existing = GetByNameCore (character.Name);
            if (existing != null)
                return null;

            return AddCore (character);
        }

       
        protected abstract Character AddCore ( Character character );

        public void Delete (int id)
        {
            DeleteCore (id);
        }
        protected abstract void DeleteCore ( int id );

        public IEnumerable<Character> GetAll()
        {
            return GetAllCore ();
        }

        protected abstract IEnumerable<Character> GetAllCore ();
        public Character Get (int id)
        {
            if (id <= 0)
                return null;

            return GetCore (id);
        }

        protected abstract Character GetCore ( int id );
        public  void Update ( int id, Character newCharacter )
        {
            if (id <=0)
                return;
            if (newCharacter==null)
                return;

            var results = ObjectValidator.TryValidateObject (newCharacter);
            if (results.Count () > 0)
                return;

            var existing = GetByNameCore (newCharacter.Name);
            if (existing != null && existing.Id != id)
                return;

            UpdateCore (id, newCharacter);
        }

        protected abstract Character UpdateCore ( int id, Character newCharacter );

        protected abstract Character GetByNameCore ( string name );
    }
}
