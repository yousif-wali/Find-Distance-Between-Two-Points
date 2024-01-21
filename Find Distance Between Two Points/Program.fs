open System


type Coordinate = {
    Latitude: float
    Longitude: float
}

type DistanceCalculator() =
    member this.Distance(coord1: Coordinate, coord2: Coordinate) =
        let radians(degrees: float) = degrees * Math.PI / 180.0

        let earthRadiusKm = 6371.0

        let dLat = radians(coord2.Latitude - coord1.Latitude)
        let dLon = radians(coord2.Longitude - coord1.Longitude)

        let lat1 = radians(coord1.Latitude)
        let lat2 = radians(coord2.Latitude)

        let a = Math.Sin(dLat / 2.0) * Math.Sin(dLat / 2.0) +
                Math.Sin(dLon / 2.0) * Math.Sin(dLon / 2.0) * Math.Cos(lat1) * Math.Cos(lat2)
        let c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a))

        earthRadiusKm * c

let coord1 = { Latitude = 40.7128; Longitude = -74.0060 } // New York City
let coord2 = { Latitude = 51.5074; Longitude = -0.1278 }  // London

let calculator = DistanceCalculator()
let distance = calculator.Distance(coord1, coord2)

printfn "The distance between the coordinates is %f kilometers." distance
