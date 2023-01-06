import React, { Component } from 'react';

export class Users extends Component {
    static displayName = Users.name;

    constructor(props) {
        super(props);
        this.state = { users: [], loading: true };
    }

    componentDidMount() {
        this.populateUserData();
    }

    static renderUsersTable(users) {
        return (
            <div style={{ 'overflow-x': 'auto' }} >
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>First Name</th>
                            <th>Last Name</th>
                        </tr>
                    </thead>
                    <tbody>
                        {users.map(user =>
                            <tr key={user.id}>
                                <td>{user.id}</td>
                                <td>{user.firstName}</td>
                                <td>{user.lastName}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }
    render() {
        let contents = this.state.loading
            ? <div className="d-flex justify-content-center"><div className="spinner-border text-primary mx-2" role="status"><span className="sr-only">Loading...</span></div><p><em>Loading...</em></p></div>
            : Users.renderUsersTable(this.state.users);

        return (
            <div>
                <h1 id="tabelLabel" >User Data</h1>
                {contents}
            </div>
        );
    }

    async populateUserData() {
        const response = await fetch('LoadUsersFromDatabase');
        const data = await response.json();
        this.setState({ users: data, loading: false });
    }

}
