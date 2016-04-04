using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HotelRESTConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            const string serverUrl = "http://localhost.fiddler:16149";




            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/hotels/5";
                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var hotel = response.Content.ReadAsAsync<Hotel>().Result;

                            Console.WriteLine("hotel : " + hotel.Name + "hoteladresse : " + hotel.Address);

                        foreach (var room in hotel.Room)
                        {
                            Console.WriteLine("room n0: "+ room.Room_No +" price: "+room.Price);
                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }
            }

            Console.ReadLine();
            return;



            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();


                string urlString = "api/hotels/2000";
                HttpResponseMessage response = client.DeleteAsync(urlString).Result;


                if (response.IsSuccessStatusCode)

                {
                    Console.WriteLine("Du har slettet et hotel");
                    Console.WriteLine("Statuskode : " + response.StatusCode);

                }

                else

                {
                    Console.WriteLine("Fejl, hotellet blev ikke slettet");
                    Console.WriteLine("Statuskode : " + response.StatusCode);

                }
            }

            Console.ReadLine();

            return;
            var MyBestNewHotel = new Hotel()
            {
                Name = "First hotel"
                ,
                Address = "Rampelyset 12"
                ,
                Hotel_No = 3000
            };

            MyBestNewHotel.Name = "Mysecond Hotel";

            Console.WriteLine("Nu kan du attache debuggeren");
            Console.ReadLine();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();


                var response = client.PutAsJsonAsync<Hotel>("API/Hotels/3000", MyBestNewHotel).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Hotellet er opdateret");
                }
                else
                {
                    Console.WriteLine("Fejl, hotellet blev ikke opdateret");
                }


            }
            Console.ReadLine();
            return;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                var response = client.PostAsJsonAsync<Hotel>("API/Hotels", MyBestNewHotel).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Hotellet er oprettet");
                    Console.WriteLine("Statuskode :" + response.StatusCode);
                }
                else
                {
                    Console.WriteLine("Fejl, hotellet er ikke oprettet");
                    Console.WriteLine("Statuskode :" + response.StatusCode);
                }


            }


            Console.ReadLine();
            return;


            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string urlString = "api/hotels";

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)

                    {
                        var hotelList = response.Content.ReadAsAsync<List<Hotel>>().Result;
                        //.Content.ReadAsAsync<List<Hotel>>().Result;

                        foreach (var hotel in hotelList)
                        {
                            Console.WriteLine("hotel : " + hotel.Name + "hoteladresse : " + hotel.Address);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl " + e.Message);                    
                }


                Console.ReadLine();






            }





            return;

            int hotelnr = 1017;

            var MyNewHotel = new Hotel()
            {
                Hotel_No = hotelnr,
                Address = "Fiddlerhotel "+hotelnr,
                Name = "Fiddler hotel",
            };


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/hotels/1014";
                try
                {
                    HttpResponseMessage response = client.DeleteAsync(urlString).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Du har slettet et hotel");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                    else
                    {
                        Console.WriteLine("Fejl, hotellet blev ikke slettet");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }

            }

            Console.ReadLine();
            


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    var response = client.PostAsJsonAsync<Hotel>("API/Hotels", MyNewHotel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Du har indsat et nyt hotel");
                        Console.WriteLine("Post Content: " + response.Content.ReadAsStringAsync());
                    }
                    else
                    {
                        Console.WriteLine("Fejl, hotellet blev ikke indsat");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }
            }

            var MyUpdatedHotel = new Hotel()
            {
                Hotel_No = 1015,
                Address = "Fiddlerhotel " + hotelnr,
                Name = "Fiddler hotel",
            };

            MyUpdatedHotel.Name = "EASJ Hotel";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    var response = client.PutAsJsonAsync<Hotel>("API/Hotels/1015", MyNewHotel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Du har opdateret et hotel");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                    else
                    {
                        Console.WriteLine("Fejl, hotellet blev ikke opdateret");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }
            }


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/hotels/1015" + hotelnr;
                try
                {
                    HttpResponseMessage response = client.DeleteAsync(urlString).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Du har slettet et hotel");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                    else
                    {
                        Console.WriteLine("Fejl, hotellet blev ikke slettet");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }

            }

            Console.ReadLine();
            return;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string urlString = "api/hotels/" + hotelnr;
                HttpResponseMessage response =  client.GetAsync(urlString).Result;
                Console.WriteLine("GetAsync : " + urlString);
                Console.WriteLine("Status code : " + response.StatusCode);
                Console.WriteLine(response.Headers.ToString());
                Console.WriteLine("Location : " + response.Headers.Location );
                if (response.IsSuccessStatusCode)
                {
                    var hotel = response.Content.ReadAsAsync<Hotel>().Result;
                    Console.WriteLine("hotel : " + hotel.Name + "hoteladresse : "+hotel.Address);
                }

            }


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/hotels";
                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var hotelList = response.Content.ReadAsAsync<List<Hotel>>().Result;

                        foreach (var hotel in hotelList)
                        {
                            Console.WriteLine("hotel : " + hotel.Name + "hoteladresse : " + hotel.Address);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " +e.Message );
                }
            }


            Console.ReadLine();

            //Guest nygæst = new Guest();



        }



        /// <summary>
        /// løsning til opgave 1
        /// </summary>
        /// <param name="serverUrl"></param>
        /// <param name="selectHotel"></param>
        private static void Excercise1(string serverUrl, int selectHotel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string urlString = "api/hotels/" + selectHotel;

                try
                {
                    var response = client.GetAsync(urlString).Result;
                    Console.WriteLine("GetAsync : " + urlString);
                    if (response.IsSuccessStatusCode)
                    {
                        var hotel = response.Content.ReadAsAsync<Hotel>().Result;
                        Console.WriteLine("hotel : " + hotel.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Error: " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception : " +e.Message);
                }

            }
        }


        private static void Exercise2(string serverUrl, List<Hotel> hotellist, List<Room> roomlist)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/hotels").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var hotels = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;

                        var roskildeHotels = hotels.Where(x => x.Address.Contains("Roskilde")).ToList();

                        hotellist.AddRange(roskildeHotels);

                        Console.WriteLine("Hotels in roskilde");
                        foreach (var rh in roskildeHotels)
                        {
                            Console.WriteLine(rh.ToString());
                        }

                        var roomresponse = client.GetAsync("api/rooms").Result;

                        if (roomresponse.IsSuccessStatusCode)
                        {
                            var rooms = roomresponse.Content.ReadAsAsync<IEnumerable<Room>>().Result;

                            var roskildeRoom = from r in rooms
                                               join h in hotellist on r.Hotel_No equals h.Hotel_No
                                               select r;

                            roomlist.AddRange(roskildeRoom.OrderBy(x => x.Hotel_No).ToList());

                            foreach (var rr in roomlist)
                            {
                                Console.WriteLine(rr.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("response error status code: " + response.StatusCode);
                        }
                    }
                    else
                    {
                        Console.WriteLine("response error status code: " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception : " + e.Message);
                }
            }
        }




    }
}    

