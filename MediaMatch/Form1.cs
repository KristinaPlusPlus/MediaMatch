using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//For API
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
//For the asynchronous problem
using System.Windows.Threading;


namespace MediaMatch
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void matchButton_Click(object sender, EventArgs e)
        {
            //Get artist from user
            movieOutput.Text = "Please Wait...";
            string userInput = artEntry.Text;

            //Check the database
            Artist userArtist = await GetArtist(userInput);
            if (userArtist == null)
            {
                movieOutput.Text ="The database is empty";
                return;
            }

            //Pick genre of movie based off music type
            string movieGenre = "";
            int count = 0;
            //Check if artist is in the list of artists
            bool isArtistInList = false;
            foreach (var artist in userArtist.data)
            {
                if(userInput == artist.name){
                    isArtistInList = true;

                    //Determine movie genre based off artist (due to lack of music genre api)
                    movieGenre = getMovieGenre(count);
                    break;
                }
                count++;
            }
            //If artist isn't in the list
            if(! isArtistInList){
                movieOutput.Text = "Your artist is not in the list";
                return;
            }

            //Retrieve list of current movies
            InTheaterMovies movieList = await GetMovie(movieGenre);
            if (movieList == null)
            {
                movieOutput.Text = "The database is empty";
                return;
            }

            //Clear out the wait message and output results
            movieOutput.Text = "";
            movieOutput.Text += "Your movie suggestions for " + movieGenre + ": \r\n \r\n";
            //Output all movies within the specified genre
            foreach (var movie in movieList.movies)
            {
                //Check each movie to see which genre it is
                string movieAPI = "http://api.rottentomatoes.com/api/public/v1.0/movies/"+ movie.id +".json?apikey=qr42wdeshx8vadq35ktdapub";

                //Check which genre is each movie in 
                //NEED TO FIX ASYNCHRONOUS CALLS
                movieEle movieElement = await GetMovieElement(movieGenre, movieAPI);
                await Task.Delay(300);

                //Check each movie to see which genre it is
                foreach (var genre in movieElement.genres)
                {
                    if (movieGenre == genre)
                    {
                        //Output the current movie
                        movieOutput.Text += movie.title +"\r\n";
                    }
                }
            }

            //Results are done
            movieOutput.Text += "\r\n Enter new artist to start another search...";
        }

        //If user presses enter
        private void inputText_KeyDown(object sender, KeyEventArgs e)
        {
            //React if user hits enter
            if (e.KeyCode != Keys.Enter) return;
            matchButton_Click(sender, e);
        }

        //For Beats right now
        private const string APIBeats = "https://partner.api.beatsmusic.com/v1/api/artists?order_by=popularity&limit=200&offset=0&client_id=6whz27druexfbpfxc7nbhkn6";
        static async Task<Artist> GetArtist(string artistName)
        {
            using (var client = new HttpClient())
            {
                //Get list of artists in database
                var url = string.Format(APIBeats, artistName);
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return JsonConvert.DeserializeObject<Artist>(json);

            }
        }

        //For Rotten Tomatoes right now
        private const string APIRottenTomatoes = "http://api.rottentomatoes.com/api/public/v1.0/lists/movies/in_theaters.json?apikey=qr42wdeshx8vadq35ktdapub";
        static async Task<InTheaterMovies> GetMovie(string movieGenre)
        {
            using (var client = new HttpClient())
            {
                //Get current movies in theater
                var url = string.Format(APIRottenTomatoes, movieGenre);
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return JsonConvert.DeserializeObject<InTheaterMovies>(json);

            }
        }

        //For Getting movie element genre
        static async Task<movieEle> GetMovieElement(string movieGenre, string movieAPI)
        {
            using (var client = new HttpClient())
            {

                //Get current movies in theater
                var url = string.Format(movieAPI, movieGenre);
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return JsonConvert.DeserializeObject<movieEle>(json);

            }
        }

        //Return a movie genre based off the artist
        string getMovieGenre(int count)
        {
            int[] actionAndAdventure;
            actionAndAdventure= new int [29] {7,23,27,28,34,46,54,79,83,95,100,116,118,119,121,122,125,128,132,135,138,148,157,159,162,176,179,180,196};
            int[] animation;
            animation = new int [22]{6,41,47,55,56,73,77,93,94,97,101,109,120,123,146,151,187,188,190,193,194,199};
            int[] comedy;
            comedy=new int[35] {12,15,20,22,25,26,32,33,37,38,48,50,64,67,69,90,96,104,107,112,126,130,133,142,149,153,163,164,170,174,184,186,189,195,198};
            int[] drama;
            drama=new int [51] {1,2,3,4,5,10,11,13,18,21,30,31,39,42,44,49,51,52,58,60,62,65,66,68,72,75,78,82,89,91,92,99,103,108,110,113,114,138,139,141,143,144,150,155,160,165,171,175,177,185,192};
            int[] horror;
            horror= new int [20] {36,43,45,53,71,80,88,111,117,129,140,147,156,166,167,168,172,173,181,182};
            int[] kidsAndFamily;
            kidsAndFamily=new int [17] {24,59,61,63,70,84,85,98,106,115,131,137,152,158,178,183,197};
            int[] mysteryAndSuspense;
            mysteryAndSuspense=new int [12] {8,19,29,35,40,57,81,86,124,127,154,191};
            int[] scienceFictionAndFantasy;
            scienceFictionAndFantasy=new int [5] {16,76,102,136,161};

            //Check each to find out which category it is in
            foreach (int i in actionAndAdventure)
            {
                if (i == count) return "Action & Adventure";
            }
            foreach (int i in animation)
            {
                if (i == count) return "Animation";
            }
            foreach (int i in comedy)
            {
                if (i == count) return "Comedy";
            }
            foreach (int i in drama)
            {
                if (i == count) return "Drama";
            }
            foreach (int i in horror)
            {
                if (i == count) return "Horror";
            }
            foreach (int i in kidsAndFamily)
            {
                if (i == count) return "Kids & Family";
            }
            foreach (int i in mysteryAndSuspense)
            {
                if (i == count) return "Mystery & Suspense"; ;
            }
            
            //Default returns science fiction and fantasy
            return "Science Fiction & Fantasy";
        }

        private void Description_Click(object sender, EventArgs e)
        {

        }

    }
}
