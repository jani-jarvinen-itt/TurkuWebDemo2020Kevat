import React from 'react';

interface AsiakasListaus_Tila {
    asiakkaat: any[];
}

class AsiakasListaus extends React.Component<{}, AsiakasListaus_Tila> {

    constructor(props: any) {
        super(props);

        console.log("AsiakasLista.constructor()");
        this.state = { asiakkaat: [] };
    }

    componentDidMount() {
        console.log("AsiakasLista.componentDidMount()");

        console.log("AsiakasLista: aloitetaan Fetch-kutsu");

        fetch("https://localhost:44306/api/asiakkaat")
            .then(response => response.json())
            .then(json => {
                console.log("AsiakasLista: Fetch-kutsu valmis");
                console.log(json);

                console.log("AsiakasLista: Ennen tilan päivitystä");
                this.setState({ asiakkaat: json });
                console.log("AsiakasLista: Tila on päivitetty!");
            });
    }

    render() {
        console.log("AsiakasLista.Render()");

        let rivit = [];
        for (let index = 0; index < this.state.asiakkaat.length; index++) {
            const työntekijä = this.state.asiakkaat[index];
            rivit.push(<tr key={index}>
                <td>{työntekijä.companyName}</td>
                <td>{työntekijä.contactName}</td>
            </tr>);
        }

        return <div>
            <h2>Asiakaslista</h2>
            <table>
                <thead>
                    <tr>
                        <th>Nimi</th>
                        <th>Yhteyshenkilö</th>
                    </tr>
                </thead>
                <tbody>
                    {rivit}
                </tbody>
            </table>
        </div>;
    }
}

export default AsiakasListaus;