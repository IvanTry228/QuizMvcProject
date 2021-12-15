namespace QuizTemplateMvcDotnet6.VideosTools
{
    public class VideoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string urlPreviewImg { get; set; }

        public string urlSourceVideo { get; set; }

        public VideoItem(string _urlPreviewImg, string _urlSourceVideo)
        {
            urlPreviewImg = _urlPreviewImg;
            urlSourceVideo = _urlSourceVideo;
        }
    }
}
