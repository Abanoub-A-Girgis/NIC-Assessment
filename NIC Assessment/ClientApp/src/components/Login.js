import React, { Component } from 'react';
import UNLogo from '../UN_emblem_blue.png';

export class Login extends Component {
    static displayName = Login.name;
    render() {
        return (
            <form className="w-50 mx-auto" method="POST" action="LoginMethod">
                <div className="col-xs-auto col-md-auto mb-4">
                    <img src={UNLogo} alt="UN Security Council Logo" className="img-fluid" />
                </div>
                <div className="form-group form-outline mb-4">
                    <div className="col-xs-auto col-md-auto">
                        <input type="text" name="userName" className="form-control" placeholder="Username" />
                    </div>
                </div>
                <div className="form-group form-outline mb-4">
                    <div className="col-xs-auto col-md-auto">
                        <input type="password" name="password" className="form-control" placeholder="Password"/>
                    </div>
                </div>
                <div className="form-group">
                    <div className="col-xs-offset-4 col-md-offset-2 col-xs-auto col-md-auto">
                        <input type="submit" value="Log in" className="btn btn-primary btn-block mb-4" />
                    </div>
                </div>
            </form>
        );
    }

    async UserLogin() {
        let formData = new FormData();
        formData.append("UserName", this.userName.value)
        formData.append("Password", this.password.value)
        const response = await fetch('LogIn', {
            method: 'POST',
            body: formData
        }
        );
        const data = await response.json();
    }
}