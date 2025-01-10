
namespace basic_api.Data
{
  public static class ErrorMessages
  {
    public static readonly object UserNotFound = new
    {
      code = "USER_NOT_FOUND",
      message = "User not found"
    };

    public static readonly object CarNotFound = new
    {
      code = "CAR_NOT_FOUND",
      message = "Car not found"
    };

    public static readonly object CarIsInUse = new
    {
      code = "CAR_IS_IN_USE",
      message = "Car is in use"
    };

    public static readonly object OrderNotValid = new
    {
      code = "ORDER_NOT_VALID",
      message = "Order not valid"
    };

    public static readonly object PunishmentNotValid = new
    {
      code = "PUNISHMENT_NOT_VALID",
      message = "Punishment not valid"
    };

    public static readonly object OrderNotFound = new
    {
      code = "ORDER_NOT_FOUND",
      message = "Order not found"
    };

    public static readonly object CarTypeNotFound = new
    {
      code = "CAR_TYPE_NOT_FOUND",
      message = "Car type not found"
    };

    public static readonly object CarTypeIsHavingCar = new
    {
      code = "CAR_TYPE_IS_HAVING_CAR",
      message = "Car type is having car"
    };

    public static readonly object UserIsNotVerified = new
    {
      code = "USER_IS_NOT_VERIFIED",
      message = "User is not verified"
    };

    public static readonly object UsernameOrPasswordIsIncorrect = new
    {
      code = "USERNAME_OR_PASSWORD_IS_INCORRECT",
      message = "Username or password is incorrect"
    };

    public static readonly object EmailAlreadyExist = new
    {
      code = "EMAIL_ALREADY_EXIST",
      message = "Email already exist"
    };

    public static readonly object UserIsVerified = new
    {
      code = "USER_IS_VERIFIED",
      message = "User is verified"
    };

    public static readonly object InvalidCode = new
    {
      code = "INVALID_CODE",
      message = "Invalid code"
    };

    public static readonly object CodeIsExpired = new
    {
      code = "CODE_IS_EXPIRED",
      message = "Code is expired"
    };

    public static readonly object NotAuthorizedToAccess = new
    {
      code = "NOT_AUTHORIZED_TO_ACCESS",
      message = "Not authorized to access"
    };

    public static readonly object AccountIsInactive = new
    {
      code = "ACCOUNT_IS_INACTIVE",
      message = "Account is inactive"
    };

    public static readonly object TokenIsInvalid = new
    {
      code = "TOKEN_IS_INVALID",
      message = "Token is invalid"
    };

    public static readonly object InvalidLoginAttempt = new
    {
      code = "INVALID_LOGIN_ATTEMPT",
      message = "Invalid Login Attempt"
    };

    public static readonly object PropertyWithThisNameNotFound = new
    {
      code = "PROPERTY_WITH_THIS_NAME_NOT_FOUND",
      message = "Property With This Name Not Found"
    };

    public static readonly object UserIsInValid = new
    {
      code = "USER_IS_INVALID",
      message = "User Is InValid"
    };
  }
}