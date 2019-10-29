using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public abstract class CharacterRoster : ICharacterRoster
    {
        public Character Add (Character character)
        {
            //if (character == null)
            //return null;
            if(character == null)
                throw new ArgumentNullException (nameof (character));

            var results = ObjectValidator.TryValidateObject (character);
            if (results.Count () > 0)
                throw new ValidationException (results.FirstOrDefault().ErrorMessage);

            var existing = GetByNameCore (character.Name);
            if (existing != null)
                throw new InvalidOperationException ("Character must be unique");

            return AddCore (character);
        }

       
        protected abstract Character AddCore ( Character character );

        public void Delete (int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException (nameof(id), "Id must be > 0");

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
                //return null;
                throw new ArgumentOutOfRangeException (nameof (id), "Id must be > 0");

            return GetCore (id);
        }

        protected abstract Character GetCore ( int id );
        public  void Update ( int id, Character newCharacter )
        {
            if (id <=0)
                throw new ArgumentOutOfRangeException (nameof (id), "Id must be > 0");
            if (newCharacter==null)
                throw new ArgumentNullException (nameof (newCharacter));

            var results = ObjectValidator.TryValidateObject (newCharacter);
            if (results.Count () > 0)
                //return;
                throw new ValidationException (results.FirstOrDefault ().ErrorMessage);

            var existing = GetByNameCore (newCharacter.Name);
            if (existing != null && existing.Id != id)
                //return;
                throw new InvalidOperationException ("Character must be unique");

            UpdateCore (id, newCharacter);
        }

        protected abstract Character UpdateCore ( int id, Character newCharacter );

        protected abstract Character GetByNameCore ( string name );
    }
}
