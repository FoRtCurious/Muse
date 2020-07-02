using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IActive
    {
        IEnumerable<ActiveAlbum > GetMusicByActiveId(int id);    //通过活动编号获取音乐
        string HideActive(int id ,int userid);     //屏蔽活动
        IEnumerable<View_showactive> GetActiveByView();      //主页活动
        IEnumerable<Active> GetActiveByJoinsum();     //音乐人主页三个活动
        IEnumerable<Activehide> GetHideActive(int id);          //获取屏蔽表中当前用户屏蔽的活动    new 
        string PublishActive(string actname, string actinfo, string orienroll, string recenroll,string image_url,int Holder);        //上传活动 new 
        IEnumerable<Active> GetCampAlbum(int id); //控制器报错
        IEnumerable<Active> GetActiveByLocation();    //历史参与
        IEnumerable<Active> GetAllActive();      //所有活动
        IEnumerable<Active> GetActiveByHolder();      //猜你喜欢
        IEnumerable<Active> GetActiveById(int id );        //我的发布 
        Active GetActiveByActno(int id);     //通过活动编号获取活动内容
        string ComplainActive(int userid, int actid, string content);     //投诉



    }
}
