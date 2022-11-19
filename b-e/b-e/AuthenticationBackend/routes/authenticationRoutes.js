const mongoose = require('mongoose');
const Account = mongoose.model('accounts');

module.exports = app => {
    //Routes
    app.post('/account/login', async(req, res) => {
    
    const {RUusername, RPassword} = req.body;
    
    if(RUusername == null || RPassword == null)
    {
        res.send("Invalid Credentials!");
        return;
    }
    
    var userAccount = await Account.findOne({username : RUusername});
    
    if(userAccount != null)
    {
        if(RPassword == userAccount.password){
            userAccount.lastAuthentication = Date.now();
            await userAccount.save();
    
            console.log("retrieving Account");
            res.send(userAccount);
            return;
        }
    }
    
    res.send("Invalid Credentials");
    
    });


    //Create Account
    app.post('/account/Create', async(req, res) => {
    
        const {RUusername, RPassword} = req.body;
        
        if(RUusername == null || RPassword == null)
        {
            res.send("Invalid Credentials!");
            return;
        }
        
        var userAccount = await Account.findOne({username : RUusername});
        
        if(userAccount == null)
        {
            console.log("create New Account");
        
            var NewAccount = new Account({
                username : RUusername,
                password : RPassword,
        
                lastAuthentication : Date.now()
            })
            await NewAccount.save();
            res.send(NewAccount);
            return;
        }
        
        else{
            res.send("Username Is Already Taken");
        }
        });
    
}

