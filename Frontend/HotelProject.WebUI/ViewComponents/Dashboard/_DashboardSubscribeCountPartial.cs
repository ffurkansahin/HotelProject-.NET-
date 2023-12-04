using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ResultInstagramFollowersDto followersDto = new ResultInstagramFollowersDto();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/alprivatzbe"),
                Headers =
    {
        { "(RAPID API KEY)" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                followersDto = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
                ViewBag.followers = followersDto.followers;
                ViewBag.following = followersDto.following;


                var client2 = new HttpClient();
                var request2 = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://twitter154.p.rapidapi.com/user/details?username=ffurkan_sahinn&user_id=96479162"),
                    Headers =
    {
        { "(RAPID API KEY)" },
        { "X-RapidAPI-Host", "twitter154.p.rapidapi.com" },
    },
                };
                using (var response2 = await client2.SendAsync(request2))
                {
                    response2.EnsureSuccessStatusCode();
                    var body2 = await response2.Content.ReadAsStringAsync();
                    ResultTwitterFollowersDto twitterFollowersDto = JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(body2);
                    ViewBag.twitterFollowers = twitterFollowersDto.follower_count;
                    ViewBag.twitterFollowing = twitterFollowersDto.following_count;
                }


                var client3 = new HttpClient();
                var request3 = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Ffurkan-%25C5%259Fahin-62759a278%2F&include_skills=false"),
                    Headers =
    {
        { "(RAPID API KEY)" },
        { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
                };
                using (var response3 = await client.SendAsync(request3))
                {
                    response3.EnsureSuccessStatusCode();
                    var body3 = await response3.Content.ReadAsStringAsync();
                    ResultLinkedinFollowersDto linkedinFollowersDto = JsonConvert.DeserializeObject<ResultLinkedinFollowersDto>(body3);
                    ViewBag.linkedinConnectionCount = linkedinFollowersDto.data.connections_count;
                    ViewBag.followerCount = linkedinFollowersDto.data.followers_count;
                }

                return View();
            }
        }
    }
}
