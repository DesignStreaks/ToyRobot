namespace ToyRobot
{
    public interface IProcessor
    {
        Status<Scene> Move(Scene scene);
        Status<Scene> Place(Scene scene, Bearing bearing);
        Status<Scene> Report(Scene scene);
        Status<Scene> Turn(Scene scene, string direction);
    }
}