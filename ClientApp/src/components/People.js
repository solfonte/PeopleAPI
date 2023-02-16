import React, {useState, useEffect} from 'react';
import CustomizedTables from './Table';


export const People = () => {

    const [people, setPeople] = useState([]);

    useEffect(() => {

        fetch(`person/`)
        .then((results) => {
            return results.json();
        })
        .then(data => {
            setPeople(data);
        })
    },[])

    return CustomizedTables(people)
}