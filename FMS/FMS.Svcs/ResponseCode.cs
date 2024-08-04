namespace FMS.Svcs
{
    public class ResponseCode
    {
        public enum Status : int
        {
            Ok = 200,
            Created = 201,
            Accepted = 202,
            NoContent = 204,
            MovedPermanently = 301,
            Found = 302,
            BadRequest = 400,
            Unauthorized = 401,
            Forbidden = 403, //understands the request but refuses to authorize it
            NotFound = 404,
            NotAllowed =405, // understood the request but refuses to authorize the requested method (e.g., GET, POST, DELETE, PUT, etc.)
        }
    }
}
