using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class MemoryCharacterRoster : CharacterRoster
    {
        protected override Character AddCore (Character character)
        {
            character.Id = ++_id;
            var newCharacter = Clone (new Character (), character);
            _characters.Add (newCharacter);

            return character;
        }

        private Character FindCharacter (int id)
        {
            foreach (var character in _characters)
                if (character.Id == id)
                    return character;

            return null;
        }
        private Character Clone (Character target, Character source)
        {
            target.Id = source.Id;
            target.Name = source.Name;
            target.Profession = source.Profession;
            target.Race = source.Race;
            target.Strength = source.Strength;
            target.Intelligence = source.Intelligence;
            target.Dexterity = source.Dexterity;
            target.Vitality = source.Vitality;
            target.Piety = source.Piety;
            target.Description = source.Description;

            return target;
        }

        protected override void DeleteCore ( int id )
        {
            var character = FindCharacter (id);
            if (character != null)
                _characters.Remove (character);
        }
        protected override IEnumerable<Character> GetAllCore ()
        {
            foreach (var character in _characters)
                yield return Clone (new Character (), character);
        }
        protected override Character GetCore ( int id )
        {
            var character = FindCharacter (id);
            return character != null ? Clone (new Character (), character) : null;
        }
        protected override Character UpdateCore ( int id, Character newCharacter )
        {
            var existing = FindCharacter (id);
            if (existing == null)
                return null;

            newCharacter.Id = id;
            Clone (existing, newCharacter);

            return newCharacter;
        }
        protected override Character GetByNameCore ( string name )
        {
            foreach (var character in _characters)
                if (String.Compare (character.Name, name, true) == 0)
                    return character;

            return null;
        }

        private List<Character> _characters = new List<Character> ();

        private int _id = 0;
    }
}
