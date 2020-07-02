using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IMusic
    {
        IEnumerable<UserMusics> GetMusic();
        IEnumerable<UserMusics> GetOriginMusic();
        IEnumerable<UserMusics> GetCoverMusic();
        IEnumerable<UserMusics> SearchMusic(string search);
        void AddListenTime(UserMusics music);
        IEnumerable<UserMusics> GetMusicByUserId(int id);
        UserMusics GetMusicById(int id);
        string AddLike(UserMusics music);
        List<UserMusics> GetMusicJson();
        string CloseMusic(int id);
        string OpenMusic(int id);
        UserMusics SearchMusicById(int id);
        IEnumerable<UpType> GetUpType();
        string AgreeCheck(int id);
        string UnAgreeCheck(int id);
        string AddMusic(UserMusics music);
        string RemoveMusic(UserMusics music);
        IEnumerable<PlayRecord> GetPlayRecordByUserId(int id);
    }
}
