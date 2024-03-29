﻿namespace Application.Common.Messages;
public static class ApplicationMessages
{
    public const string RecordNotfound = "رکورد یافت نشد";

    #region Bakset
    public const string BasketNotFound = "سبد خرید شما یافت نشد!";
    #endregion

    #region Auth
    public const string ConfirmCodeIsWrong = "کد تایید اشتباه است !";
    public const string ErrorInConfirmPhoneNumber = "خطا در تایید تلفن همراه!";
    public const string Jwt500Error = "مشکلی در احراز ویت شما در سمت سرور رخ داده است لطفا مجدد تلاش کنید!";
    public const string Jwt401Error = "شما هنوز احراز هویت نشده اید لطفا مجدد تلاش کنید!";
    public const string Jwt403ErrorNotAccess = "شما به این بخش دسترسی ندارید لطفا ابتدا وارد سایت شوید!";
    #endregion
    
    public const string FailedOperation = "عملیات موفقیت امیز نبود!";
    public const string FailedUploadPicture = "اپود عکس انجام نشد";

    #region Product
    public const string ProductDeleteFailed = "محصول حذف نشد! ";
    public const string ProductFailedDeleteOnHandle = "محصول حذف نشد! HandelError";
    public const string ProductEditFailed = "محصول ادیت نشد! ";
    public const string ProductNotFound = "محصول یافت نشد! ";
    public const string ProductAddFailed = "محصول ساخته نشد! ";
    public const string ProductAddFailedOnHandle = "محصول ساخته نشد! HandelError";
    public const string ProductEditFailedOnHandle = "محصول اذیت نشد! HandelError";
    #endregion

    #region Brand
    public const string BrandDeleteFailed = "برند حذف نشد! ";
    public const string BrandFailedDeleteOnHandle = "برند حذف نشد! HandelError";
    public const string BrandEditFailed = "برند ادیت نشد! ";
    public const string BrandNotFound = "برند یافت نشد! ";
    public const string BrandAddFailed = "برند ساخته نشد! ";
    public const string BrandAddFailedOnHandle = "برند ساخته نشد! HandelError";
    public const string BrandEditFailedOnHandle = "برند اذیت نشد! HandelError";
    #endregion
    
    #region Off
    public const string OffDeleteFailed = "تخفیف حذف نشد! ";
    public const string OffFailedDeleteOnHandle = "تخفیف حذف نشد! HandelError";
    public const string OffEditFailed = "تخفیف ادیت نشد! ";
    public const string OffNotFound = "تخفیف یافت نشد! ";
    public const string OffAddFailed = "تخفیف ساخته نشد! ";
    public const string OffAddFailedOnHandle = "تخفیف ساخته نشد! HandelError";
    public const string OffEditFailedOnHandle = "تخفیف اذیت نشد! HandelError";
    #endregion

    #region Inventory
    public const string InventoryNotFound = "انبار پیدا نشد!";
    public const string InventoryAddFailed = "انبار ساخته نشد!";
    public const string InventoryFailedDelete = "انبار حذف نشد!";
    public const string InventoryFailedEdit = "انبار ادیت نشد!";
    public const string InventoryFailedDeleteHasProduct = "انبار حذف نشد!این انبار محصول دارد لطفا ابتدا محصول این انبار را حذف کنید. تعداد محصول:";
    public const string InventoryFailedDeleteOnHandle = "انبار ادیت نشد!HendleError";
    #endregion
    
    #region Message
    public const string MessageNotFound = "انبار پیدا نشد!";
    public const string MessageAddFailed = "پیام ارسال نشد!";
    public const string MessageFailedDelete = "انبار حذف نشد!";
    public const string MessageFailedEdit = "انبار ادیت نشد!";
    public const string MessageFailedDeleteOnHandle = "انبار ادیت نشد!HendleError";
    #endregion

    #region StoreUser
    public const string StoreUserFailedEdit = "ادیت مغازه انجام نشد!";
    public const string StoreUserPictureFailedAddOnHandle = "عکس مغازه اضاف نشد !HandleError";
    public const string StoreUserPictureFailedAdd = "عکس مغازه اضاف نشد !";
    public const string StoreUserPictureNotFound = "عکس مغازه یافت نشد !";
    public const string StoreUserPictureFailedEdit = "عکس مغازه ادیت نشد !";
    public const string StoreUserPictureFailedDelete = "عکس مغازه حذف نشد !";
    #endregion

    #region Store
    public const string StoreFailedEdit = "ادیت مغازه انجام نشد!";
    public const string StoreFailedEditOnHandle = "ادیت مغازه انجام نشد! HandleError";
    public const string StoreAddFailed = "مغازه ساخته نشد!";
    public const string StoreFailedAddOnHandle = "مغازه ساخته نشد! HandleError";
    public const string StoreFailedDelete = "مغازه پاک نشد!";
    public const string StoreFailedDeleteOnHandle = "مغازه پاک نشد! HandleError";
    public const string StoreNotFound = "مغازه یافت نشد!";
    #endregion
    
    #region InventoryOperation
    public const string InventoryOperationDeleteFailed = "گزارش حذف نشد! ";
    public const string InventoryOperationFailedDeleteOnHandle = "گزارش حذف نشد! HandelError";
    public const string InventoryOperationEditFailed = "گزارش ادیت نشد! ";
    public const string InventoryOperationNotFound = "گزارش یافت نشد! ";
    public const string InventoryOperationAddFailed = "گزارش ساخته نشد! ";
    public const string InventoryOperationAddFailedOnHandle = "گزارش ساخته نشد! HandelError";
    public const string InventoryOperationEditFailedOnHandle = "گزارش اذیت نشد! HandelError";
    #endregion

    #region Type
    public const string TypeFailedEdit = "حذف دسته انجام نشد !";
    public const string TypeFailedEditOnHandle = "حذف دسته انجام نشد ! HandleError";
    public const string TypeFailedDelete = "حذف دسته انجام نشد !";
    public const string TypeFailedDeleteOnHandle = "حذف دسته انجام نشد! HandleError";
    public const string TypeFailedAdd = "دسته اضافه نشد!";
    public const string TypeNotFound = "دسته یافت نشد!";
    #endregion
    
    #region Favorite
    public const string FavoriteFailedEdit = "حذف علاقه مندی انجام نشد !";
    public const string FavoriteFailedEditOnHandle = "حذف علاقه مندی انجام نشد ! HandleError";
    public const string FavoriteFailedDelete = "حذف علاقه مندی انجام نشد !";
    public const string FavoriteFailedDeleteOnHandle = "حذف علاقه مندی انجام نشد! HandleError";
    public const string FavoriteFailedAdd = "علاقه مندی اضافه نشد!";
    public const string FavoriteNotFound = "علاقه مندی یافت نشد!";
    #endregion
    
    #region Connection
    public const string ConnectionFailedEdit = "حذف اتصال انجام نشد !";
    public const string ConnectionFailedEditOnHandle = "حذف اتصال انجام نشد ! HandleError";
    public const string ConnectionFailedDelete = "حذف اتصال انجام نشد !";
    public const string ConnectionFailedDeleteOnHandle = "حذف اتصال انجام نشد! HandleError";
    public const string ConnectionFailedAdd = "اتصال اضافه نشد!";
    public const string ConnectionNotFound = "اتصال یافت نشد!";
    #endregion
    
    #region Group
    public const string GroupFailedEdit = "حذف گروه انجام نشد !";
    public const string GroupFailedEditOnHandle = "حذف گروه انجام نشد ! HandleError";
    public const string GroupFailedDelete = "حذف گروه انجام نشد !";
    public const string GroupFailedDeleteOnHandle = "حذف گروه انجام نشد! HandleError";
    public const string GroupFailedAdd = "گروه اضافه نشد!";
    public const string GroupNotFound = "گروه یافت نشد!";
    #endregion

    #region TypePicture
    public const string TypePictureFailedEdit = "ادیت عکس دسته انجام نشد !";
    public const string TypePictureFailedEditOnHandle = "ادیت عکس دسته انجان نشد ! HandleError";
    public const string TypePictureNotFound = "عکس دسته بندی یافت نشد!";
    public const string TypePictureFailedAdd = "عکس دسته بندی اضاف  نشد!";
    public const string TypePictureFailedAddOnHandle = "عکس دسته بندی اضاف نشد!";
    public const string TypePictureFailedDelete = "عکس دسته بندی حذف نشد!";
    public const string TypePictureFailedDeleteOnHandle = "عکس دسته بندی حذف نشد!HandleError";
    #endregion
    
    #region UserPicture
    public const string UserPictureFailedEdit = "ادیت عکس کاربر انجام نشد !";
    public const string UserPictureFailedEditOnHandle = "ادیت عکس کاربر انجام نشد ! HandleError";
    public const string UserPictureNotFound = "عکس کاربر بندی یافت نشد!";
    public const string UserPictureFailedAdd = "عکس کاربر بندی اضاف  نشد!";
    public const string UserPictureFailedAddOnHandle = "عکس کاربر بندی اضاف نشد!";
    public const string UserPictureFailedDelete = "عکس کاربر بندی حذف نشد!";
    public const string UserPictureFailedDeleteOnHandle = "عکس کاربر بندی حذف نشد!HandleError";
    #endregion
    
    #region Color
    public const string ColorFailedEdit = "ادیت رنگ انجام نشد !";
    public const string ColorFailedEditOnHandle = "ادیت رنگ انجان نشد ! HandleError";
    public const string ColorNotFound = "رنگ بندی یافت نشد!";
    public const string ColorFailedAdd = "رنگ بندی اضاف  نشد!";
    public const string ColorFailedAddOnHandle = "رنگ بندی اضاف نشد!";
    public const string ColorFailedDelete = "رنگ بندی حذف نشد!";
    public const string ColorFailedDeleteOnHandle = "رنگ بندی حذف نشد!HandleError";
    #endregion
    
    #region TypeItem
    public const string TypeItemFailedEdit = "ادیت ایتم انجام نشد !";
    public const string TypeItemFailedEditOnHandle = "ادیت ایتم انجان نشد ! HandleError";
    public const string TypeItemNotFound = "ایتم بندی یافت نشد!";
    public const string TypeItemFailedAdd = "ایتم بندی اضاف  نشد!";
    public const string TypeItemFailedAddOnHandle = "ایتم بندی اضاف نشد!";
    public const string TypeItemFailedDelete = "ایتم بندی حذف نشد!";
    public const string TypeItemFailedDeleteOnHandle = "ایتم بندی حذف نشد!HandleError";
    #endregion
    
    #region ProductItem
    public const string ProductItemFailedEdit = "ادیت ایتم انجام نشد !";
    public const string ProductItemFailedEditOnHandle = "ادیت ایتم انجان نشد ! HandleError";
    public const string ProductItemNotFound = "ایتم بندی یافت نشد!";
    public const string ProductItemFailedAdd = "ایتم بندی اضاف  نشد!";
    public const string ProductItemFailedAddOnHandle = "ایتم بندی اضاف نشد!";
    public const string ProductItemFailedDelete = "ایتم بندی حذف نشد!";
    public const string ProductItemFailedDeleteOnHandle = "ایتم بندی حذف نشد!HandleError";
    #endregion
    
    #region ProductPicture
    public const string ProductPictureEditFailed = "ادیت عکس محصول انجام نشد !";
    public const string ProductPictureEditFailedOnHandle = "ادیت عکس محصول انجام نشد ! HandleError";
    public const string ProductPictureNotFound = "عکس  محصول یافت نشد!";
    public const string ProductPictureAddFailed= "عکس  محصول اضاف  نشد!";
    public const string ProductPictureAddFailedOnHandle = "عکس  محصول اضاف نشد!";
    public const string ProductPictureDeleteFailed = "عکس  محصول حذف نشد!";
    public const string ProductPictureDeleteFailedOnHandle = "عکس  محصول حذف نشد!HandleError";
    #endregion
    
    #region User
    public const string UserFailedAdd = "عملیات ساخت کاربر انجام نشد !";
    public const string UserNotFound = "کاربر یافت نشد !";
    public const string UserWrong = "نام کاربری یا رمز عبور اشتباه است !";
    public const string UserDuplicate = "شماره همراه قبلا ثبت نام شده است!";
    public const string UserFailedDelete = "کاربر حذف نشد!";
    public const string UserFailedEdit = "ادیت مغازه انجام نشد!";
    public const string UserDeleteFailed = "کاربر حذف نشد!";
    #endregion

    public const string PleaseEnterPhone = "لطفا شماره همراه خود را وارد کنید!";
    public const string PleaseEnterUsername = "لطفا نام کاربری خود را وارد کنید!";
    public const string PleaseEnterPassword = "لطفا کلمه عبور را وارد کنید!";
}