using SuperHeroAPI.Models.SuperHeroModel;

namespace SuperHeroAPI.Data
{
    public class ResponseMessage
    {
        public bool Success { get; set; }
        public string Message { get; set; }


        public ResponseMessage()
        {

        }

        public ResponseMessage ValidateSuperHero(SuperHero hero)
        {
            if (string.IsNullOrEmpty(hero.Name))
                return new ResponseMessage { Success = false, Message = "Super Hero name Cannot bem null!" };

            if (string.IsNullOrEmpty(hero.FirstName))
                return new ResponseMessage { Success = false, Message = "Super Hero first name Cannot bem null!" };

            if (string.IsNullOrEmpty(hero.LastName))
                return new ResponseMessage { Success = false, Message = "Super Hero last name Cannot bem null!" };

            if (string.IsNullOrEmpty(hero.Place))
                return new ResponseMessage { Success = false, Message = "Super Hero place Cannot bem null!" };

            return new ResponseMessage { Success = true, Message = "OK" };
        }

    }
}
