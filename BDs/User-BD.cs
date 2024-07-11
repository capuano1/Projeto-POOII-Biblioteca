using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserBD {

    private static UserBD? BD;
    private List<IUser> UserList;

    private UserBD() {
        UserList = new List<IUser>();
    }

    public static UserBD instanciaBD() {
        if (BD == null) BD = new UserBD();
        return BD;
    }

    public void registraUsuario(IUser user) {
        UserList.Add(user);
    }
}