namespace TreinarRPG.Entities;

public class CampaignControl
{
    private int storyProgress = 0;
    
    public void AdvanceStory()
    {
        storyProgress++;
    }

    public int GetStoryProgress()
    {
        return storyProgress;
    }
    
    
}