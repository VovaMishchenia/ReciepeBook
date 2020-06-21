using ReciepeBook.Model;
using System.Collections.Generic;
using System.Linq;


namespace ReciepeBook.ViewModel.Helper
{

    public class ReciepeBookHelper
    {
        static public Сulinary_recipeEntities dbReciepe = new Сulinary_recipeEntities();
        public static List<Reciepe> GetReciepes()
        {
           
            List<Reciepe> reciepes = new List<Reciepe>();
            reciepes = dbReciepe.Reciepe.ToList();
            return reciepes;
        }
        public static List<Cuisine> GetCuisines()
        {
            List<Cuisine> cuisines = new List<Cuisine>();
            cuisines = dbReciepe.Cuisine.ToList();
            return cuisines;
        }
        public static List<ReciepeType> GetReciepeTypes()
        {
            List<ReciepeType> reciepeTypes = new List<ReciepeType>();

            reciepeTypes = (from r in dbReciepe.ReciepeType
                            orderby r.Id
                            select r).ToList();
            return reciepeTypes;
        }
        public static List<Reciepe> GetReciepesByType(ReciepeType type)
        {
            List<Reciepe> reciepes = new List<Reciepe>();

            reciepes = (from r in dbReciepe.Reciepe
                        where r.TypeId == type.Id
                        select r).ToList();
            return reciepes;
        }

        public static List<Reciepe> GetReciepesByCategory(Cuisine cuisine, int? rating, int? calories, int? cookingTime)
        {
            List<Reciepe> reciepes = new List<Reciepe>();
            List<Reciepe> temp = new List<Reciepe>();
            if (cuisine != null)
            {
                reciepes = (from r in dbReciepe.Reciepe
                            where r.CuisineId == cuisine.Id
                            select r).ToList();
            }
            else
            {
                if (rating != null)
                {
                    reciepes = (from r in dbReciepe.Reciepe
                                where r.Rating >= rating
                                select r).ToList();
                }
                else
                {
                    if (calories != null)
                    {
                        reciepes = (from r in dbReciepe.Reciepe
                                    where r.Calories <= calories
                                    select r).ToList();
                    }
                    else
                     {
                        if (cookingTime != null)
                        {
                            reciepes = (from r in dbReciepe.Reciepe
                                        where r.CookingTime <= cookingTime
                                        select r).ToList();
                        }
                    }
                }
            }
            if (rating != null)
            {
                temp = reciepes;
                for (int i = 0; i < reciepes.Count; i++)
                {
                    if (reciepes[i].Rating < rating)
                        temp.RemoveAt(i);
                }
                reciepes = temp;

            }

             if (calories != null)
            {
                temp = reciepes;
                for (int i = 0; i < reciepes.Count; i++)
                {
                    if (reciepes[i].Calories > calories)
                        temp.RemoveAt(i);
                }
                reciepes = temp;
            }

             if (cookingTime != null)
            {
                temp = reciepes;
                for (int i = 0; i < reciepes.Count; i++)
                {
                    if (reciepes[i].CookingTime > cookingTime)
                        temp.RemoveAt(i);
                }
                reciepes = temp;
            }

            return reciepes;
        }
    }
}
