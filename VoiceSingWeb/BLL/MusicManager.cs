using System.Collections.Generic;
using DALFactory;
using Models;
using IDAL;

namespace BLL
{
     public class MusicManager
    {
        IMusic imusic = DataAccess.CreateMusic();
        public IEnumerable<UserMusics> GetMusic()
        {
            var musics = imusic.GetMusic();
            return musics;
        }
        public IEnumerable<UserMusics> GetOriginMusic()
        {
            var musics = imusic.GetOriginMusic();
            return musics;
        }
        public IEnumerable<UserMusics> GetCoverMusic()
        {
            var musics = imusic.GetCoverMusic();
            return musics;
        }
        public IEnumerable<UserMusics> SearchMusic(string search)
        {
            var musics = imusic.SearchMusic(search);
            return musics;
        }
        public string AddLike(UserMusics music)
        {
            return imusic.AddLike(music);
        }
        public void AddListenTime(UserMusics music)
        {
            imusic.AddListenTime(music);
        }
        public IEnumerable<UserMusics> GetMusicByUserId(int userid)
        {
            var musics = imusic.GetMusicByUserId(userid);
            return musics;
        }
        public UserMusics GetMusicById(int id)
        {
            var music = imusic.GetMusicById(id);
            return music;
        }
        public List<UserMusics> GetMusicJson()
        {
            var music = imusic.GetMusicJson();
            return music;
        }
        public string CloseMusic(int id)
        {
            string msg = imusic.CloseMusic(id);
            return msg;
        }
        public string OpenMusic(int id)
        {
            string msg = imusic.OpenMusic(id);
            return msg;
        }
        public UserMusics SearchMusicById(int id)
        {
            var music = imusic.SearchMusicById(id);
            return music;
        }
        public IEnumerable<UpType> GetUpType()
        {
            var uptype = imusic.GetUpType();
            return uptype;
        }
        public string AgreeCheck(int id)
        {
            return imusic.AgreeCheck(id);
        }
        public string UnAgreeCheck(int id)
        {
            return imusic.UnAgreeCheck(id);
        }
        public string AddMusic(UserMusics music)
        {
            return imusic.AddMusic(music);
        }
        public string RemoveMusic(UserMusics music)
        {
            return imusic.RemoveMusic(music);
        }
        public IEnumerable<PlayRecord> GetPlayRecordByUserId(int id)
        {
            return imusic.GetPlayRecordByUserId(id);
        }
    }
}
