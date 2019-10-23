using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {        
        static HumaneSocietyDataContext db;

        static Query()
        {
            db = new HumaneSocietyDataContext();
        }

        internal static List<USState> GetStates()
        {
            List<USState> allStates = db.USStates.ToList();       

            return allStates;
        }
            
        internal static Client GetClient(string userName, string password)
        {
            Client client = db.Clients.Where(c => c.UserName == userName && c.Password == password).Single();

            return client;
        }

        internal static List<Client> GetClients()
        {
            List<Client> allClients = db.Clients.ToList();

            return allClients;
        }

        internal static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int stateId)
        {
            Client newClient = new Client();

            newClient.FirstName = firstName;
            newClient.LastName = lastName;
            newClient.UserName = username;
            newClient.Password = password;
            newClient.Email = email;

            Address addressFromDb = db.Addresses.Where(a => a.AddressLine1 == streetAddress && a.Zipcode == zipCode && a.USStateId == stateId).FirstOrDefault();

            // if the address isn't found in the Db, create and insert it
            if (addressFromDb == null)
            {
                Address newAddress = new Address();
                newAddress.AddressLine1 = streetAddress;
                newAddress.City = null;
                newAddress.USStateId = stateId;
                newAddress.Zipcode = zipCode;                

                db.Addresses.InsertOnSubmit(newAddress);
                db.SubmitChanges();

                addressFromDb = newAddress;
            }

            // attach AddressId to clientFromDb.AddressId
            newClient.AddressId = addressFromDb.AddressId;

            db.Clients.InsertOnSubmit(newClient);

            db.SubmitChanges();
        }

        internal static void UpdateClient(Client clientWithUpdates) 
        {
            // find corresponding Client from Db
            Client clientFromDb = null;

            try
            {
                clientFromDb = db.Clients.Where(c => c.ClientId == clientWithUpdates.ClientId).Single();
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("No clients have a ClientId that matches the Client passed in.");
                Console.WriteLine("No update have been made.");
                return;
            }
            
            // update clientFromDb information with the values on clientWithUpdates (aside from address)
            clientFromDb.FirstName = clientWithUpdates.FirstName;
            clientFromDb.LastName = clientWithUpdates.LastName;
            clientFromDb.UserName = clientWithUpdates.UserName;
            clientFromDb.Password = clientWithUpdates.Password;
            clientFromDb.Email = clientWithUpdates.Email;

            // get address object from clientWithUpdates
            Address clientAddress = clientWithUpdates.Address;

            // look for existing Address in Db (null will be returned if the address isn't already in the Db
            Address updatedAddress = db.Addresses.Where(a => a.AddressLine1 == clientAddress.AddressLine1 && a.USStateId == clientAddress.USStateId && a.Zipcode == clientAddress.Zipcode).FirstOrDefault();

            // if the address isn't found in the Db, create and insert it
            if(updatedAddress == null)
            {
                Address newAddress = new Address();
                newAddress.AddressLine1 = clientAddress.AddressLine1;
                newAddress.City = null;
                newAddress.USStateId = clientAddress.USStateId;
                newAddress.Zipcode = clientAddress.Zipcode;                

                db.Addresses.InsertOnSubmit(newAddress);
                db.SubmitChanges();

                updatedAddress = newAddress;
            }

            // attach AddressId to clientFromDb.AddressId
            clientFromDb.AddressId = updatedAddress.AddressId;
            
            // submit changes
            db.SubmitChanges();
        }
        
        internal static void AddUsernameAndPassword(Employee employee)
        {
            Employee employeeFromDb = db.Employees.Where(e => e.EmployeeId == employee.EmployeeId).FirstOrDefault();

            employeeFromDb.UserName = employee.UserName;
            employeeFromDb.Password = employee.Password;

            db.SubmitChanges();
        }

        internal static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            Employee employeeFromDb = db.Employees.Where(e => e.Email == email && e.EmployeeNumber == employeeNumber).FirstOrDefault();

            if (employeeFromDb == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return employeeFromDb;
            }
        }

        internal static Employee EmployeeLogin(string userName, string password)
        {
            Employee employeeFromDb = db.Employees.Where(e => e.UserName == userName && e.Password == password).FirstOrDefault();

            return employeeFromDb;
        }

        internal static bool CheckEmployeeUserNameExist(string userName)
        {
            Employee employeeWithUserName = db.Employees.Where(e => e.UserName == userName).FirstOrDefault();

            return employeeWithUserName == null;
        }


        //// TODO Items: ////
        
        // TODO: Allow any of the CRUD operations to occur here
        internal static void RunEmployeeQueries(Employee employee, string crudOperation)
        {
            switch (crudOperation)
            {
                case "create":
                    throw new NotImplementedException();
                    break;
                case "read":
                    throw new NotImplementedException();
                    break;
                case "update":
                    throw new NotImplementedException();
                    break;
                case "delete":
                    throw new NotImplementedException();
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }

        // TODO: Animal CRUD Operations
        internal static void AddAnimal(Animal animal)
        {
            db.Animals.InsertOnSubmit(animal);
            db.SubmitChanges();

        }

        internal static Animal GetAnimalByID(int id)
        {
            Animal animalFromDb = db.Animals.Where(a => a.AnimalId == id).FirstOrDefault();
            if(animalFromDb == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return animalFromDb;
            }
        }

        internal static void UpdateAnimal(int animalId, Dictionary<int, string> updates)
        {
            Animal animalFromDb = GetAnimalByID(animalId);
            if (updates.ContainsKey(1)) //Category
            {
                animalFromDb.Category = db.Categories.Where(c => c.Name == updates[1]).FirstOrDefault();
            }
            else if (updates.ContainsKey(2)) //Name
            {
                animalFromDb.Name = updates[2];
            }
            else if (updates.ContainsKey(3)) //Age
            {
                try
                {
                    animalFromDb.Age = Convert.ToInt32(updates[3]);
                }
                catch
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            else if (updates.ContainsKey(4)) //Demeanor
            {
                animalFromDb.Demeanor = updates[4];
            }
            else if (updates.ContainsKey(5)) //KidFriendly (Bool)
            {
                try
                {
                    animalFromDb.KidFriendly = Convert.ToBoolean(updates[5]);
                }
                catch
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            else if (updates.ContainsKey(6)) //PetFriendly (Bool)
            {
                try
                {
                    animalFromDb.PetFriendly = Convert.ToBoolean(updates[6]);
                }
                catch
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            else if (updates.ContainsKey(7)) //Weight
            {
                try
                {
                    animalFromDb.Weight = Convert.ToInt32(updates[7]);
                }
                catch
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            db.SubmitChanges();
        }

        internal static void RemoveAnimal(Animal animal)
        {
            Animal animalFromDb = GetAnimalByID(animal.AnimalId);
            db.Animals.DeleteOnSubmit(animalFromDb);
            db.SubmitChanges();
        }
        
        // TODO: Animal Multi-Trait Search
        internal static IQueryable<Animal> SearchForAnimalsByMultipleTraits(Dictionary<int, string> updates) // parameter(s)?
        {
            IQueryable<Animal> animals;
            if (updates.ContainsKey(1)) //Category
            {
                var category = db.Categories.Where(c => c.Name == updates[1]).FirstOrDefault();
                return db.Animals.Where(a => a.CategoryId == category.CategoryId);
            }
            else if (updates.ContainsKey(2)) //Name
            {
                return db.Animals.Where(a => a.Name == updates[2]);
            }
            else if (updates.ContainsKey(3)) //Age
            {
                try
                {
                    int age = Convert.ToInt32(updates[3]);
                    return db.Animals.Where(a => a.Age == age);

                }
                catch
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            else if (updates.ContainsKey(4)) //Demeanor
            {
                return db.Animals.Where(a => a.Demeanor == updates[4]);
            }
            else if (updates.ContainsKey(5)) //KidFriendly (Bool)
            {
                return db.Animals.Where(a => a.KidFriendly == true);
            }
            else if (updates.ContainsKey(6)) //PetFriendly (Bool)
            {
                return db.Animals.Where(a => a.PetFriendly == true);
            }
            else if (updates.ContainsKey(7)) //Weight
            {
                try
                {
                    int weight = Convert.ToInt32(updates[7]);
                    return db.Animals.Where(a => a.Weight == weight);
                }
                catch
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            return null;
        }
         
        // TODO: Misc Animal Things
        internal static int GetCategoryId(string categoryName)
        {
            Category category = db.Categories.Where(c => c.Name == categoryName).Single();

            return category.CategoryId;
        }
        
        internal static Room GetRoom(int animalId)
        {
            Room room = db.Rooms.Where(r => r.AnimalId == animalId).Single();

            return room;
        }
        
        internal static int GetDietPlanId(string dietPlanName)
        {
            DietPlan dietPlan = db.DietPlans.Where(d => d.Name == dietPlanName).Single();

            return dietPlan.DietPlanId;
        }

        // TODO: Adoption CRUD Operations
        internal static void Adopt(Animal animal, Client client)
        {
            Adoption newAdoption = new Adoption();
            newAdoption.AnimalId = animal.AnimalId;
            newAdoption.ClientId = client.ClientId;
            newAdoption.ApprovalStatus = "pending";
            newAdoption.AdoptionFee = 20;
            newAdoption.PaymentCollected = false;
            db.Adoptions.InsertOnSubmit(newAdoption);
            db.SubmitChanges();
        }

        internal static IQueryable<Adoption> GetPendingAdoptions()
        {
            return db.Adoptions.Where(a => a.ApprovalStatus == "pending");
        }

        internal static void UpdateAdoption(bool isAdopted, Adoption adoption)
        {
            if (isAdopted == true)
            {
                adoption.ApprovalStatus = "Approved";
                adoption.PaymentCollected = true;
                
            }
            else 
            {
                adoption.ApprovalStatus = "Approved";
            }
            db.SubmitChanges();
        }

        internal static void RemoveAdoption(int animalId, int clientId)
        {
            Adoption adoptionFromDb = db.Adoptions.Where(a => a.AnimalId == animalId && a.ClientId == clientId).FirstOrDefault();
            db.Adoptions.DeleteOnSubmit(adoptionFromDb);
            db.SubmitChanges();
        }

        // TODO: Shots Stuff
        internal static IQueryable<AnimalShot> GetShots(Animal animal)
        {
            return db.AnimalShots.Where(a => a.AnimalId == animal.AnimalId);
        }

        internal static void UpdateShot(string shotName, Animal animal)
        {
            Shot shotFromDb = db.Shots.Where(s => s.Name == shotName).FirstOrDefault();
            AnimalShot animalShot = new AnimalShot();
            animalShot.AnimalId = animal.AnimalId;
            animalShot.ShotId = shotFromDb.ShotId;
            animalShot.DateReceived = DateTime.Today;
            db.AnimalShots.InsertOnSubmit(animalShot);
            db.SubmitChanges();
        }
    }
}