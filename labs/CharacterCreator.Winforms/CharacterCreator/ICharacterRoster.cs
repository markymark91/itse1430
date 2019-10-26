using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public interface ICharacterRoster
    {
        Character Add ( Character character );

        Character Get ( int id );
        IEnumerable<Character> GetAll ();

        void Delete ( int id );

        void Update ( int id, Character newCharacter );
    }
}
