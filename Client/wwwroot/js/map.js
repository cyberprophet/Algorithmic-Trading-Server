function initialize()
{
    const div = document.getElementById("map")

    if (div instanceof (HTMLDivElement))
    {
        map = new google.maps.Map(div, {
            center: {
                lat: latitude,
                lng: longitude
            },
            zoom: 15,
            styles: styleOfBright
        })
    }
}
function toSearchLocation()
{
    if (navigator.geolocation)
    {
        navigator.geolocation.getCurrentPosition(position =>
        {
            const pc = position.coords

            longitude = pc.longitude
            latitude = pc.latitude
        },
            error =>
            {
                latitude = 37.4015893
                longitude = 127.1084358

                console.log(error.message)
            })
    }
    else
    {
        longitude = 127.013685
        latitude = 37.294779
    }
}
const styleOfDark =
    [{
        elementType: "geometry",
        stylers: [
            {
                color: "#242f3e"
            }
        ]
    },
    {
        elementType: "labels.text.stroke",
        stylers: [
            {
                color: "#242f3e"
            }
        ]
    },
    {
        elementType: "labels.text.fill",
        stylers: [
            {
                color: "#746855"
            }
        ]
    },
    {
        featureType: "administrative.locality",
        elementType: "labels.text.fill",
        stylers: [
            {
                color: "#d59563"
            }
        ]
    },
    {
        featureType: "poi",
        elementType: "labels.text.fill",
        stylers: [
            {
                color: "#d59563"
            }
        ]
    },
    {
        featureType: "poi.park",
        elementType: "geometry",
        stylers: [
            {
                color: "#263c3f"
            }
        ]
    },
    {
        featureType: "poi.park",
        elementType: "labels.text.fill",
        stylers: [
            {
                color: "#6b9a76"
            }
        ]
    },
    {
        featureType: "road",
        elementType: "geometry",
        stylers: [
            {
                color: "#38414e"
            }
        ]
    },
    {
        featureType: "road",
        elementType: "geometry.stroke",
        stylers: [
            {
                color: "#212a37"
            }
        ]
    },
    {
        featureType: "road",
        elementType: "labels.text.fill",
        stylers: [
            {
                color: "#9ca5b3"
            }
        ]
    },
    {
        featureType: "road.highway",
        elementType: "geometry",
        stylers: [
            {
                color: "#746855"
            }
        ]
    },
    {
        featureType: "road.highway",
        elementType: "geometry.stroke",
        stylers: [
            {
                color: "#1f2835"
            }
        ]
    },
    {
        featureType: "road.highway",
        elementType: "labels.text.fill",
        stylers: [
            {
                color: "#f3d19c"
            }
        ]
    },
    {
        featureType: "transit",
        elementType: "geometry",
        stylers: [
            {
                color: "#2f3948"
            }
        ]
    },
    {
        featureType: "transit.station",
        elementType: "labels.text.fill",
        stylers: [
            {
                color: "#d59563"
            }
        ]
    },
    {
        featureType: "water",
        elementType: "geometry",
        stylers: [
            {
                color: "#17263c"
            }
        ]
    },
    {
        featureType: "water",
        elementType: "labels.text.fill",
        stylers: [
            {
                color: "#515c6d"
            }
        ]
    },
    {
        featureType: "water",
        elementType: "labels.text.stroke",
        stylers: [
            {
                color: "#17263c"
            }
        ]
    }]
const styleOfBright =
    [{
        elementType: 'geometry',
        stylers: [
            {
                color: '#f5f5f5'
            }
        ]
    },
    {
        elementType: 'labels.icon',
        stylers: [
            {
                visibility: 'off'
            }
        ]
    },
    {
        elementType: 'labels.text.fill',
        stylers: [
            {
                color: '#616161'
            }
        ]
    },
    {
        elementType: 'labels.text.stroke',
        stylers: [
            {
                color: '#f5f5f5'
            }
        ]
    },
    {
        featureType: 'administrative.land_parcel',
        elementType: 'labels.text.fill',
        stylers: [
            {
                color: '#bdbdbd'
            }
        ]
    },
    {
        featureType: 'poi',
        elementType: 'geometry',
        stylers: [
            {
                color: '#eeeeee'
            }
        ]
    },
    {
        featureType: 'poi',
        elementType: 'labels.text.fill',
        stylers: [
            {
                color: '#757575'
            }
        ]
    },
    {
        featureType: 'poi.park',
        elementType: 'geometry',
        stylers: [
            {
                color: '#e5e5e5'
            }
        ]
    },
    {
        featureType: 'poi.park',
        elementType: 'labels.text.fill',
        stylers: [
            {
                color: "#9e9e9e"
            }
        ]
    },
    {
        featureType: "road",
        elementType: "geometry",
        stylers: [
            {
                color: "#ffffff"
            }
        ]
    },
    {
        featureType: "road.arterial",
        elementType: "labels.text.fill",
        stylers: [
            {
                color: "#757575"
            }
        ]
    },
    {
        featureType: "road.highway",
        elementType: "geometry",
        stylers: [
            {
                color: "#dadada"
            }
        ]
    },
    {
        featureType: "road.highway",
        elementType: "labels.text.fill",
        stylers: [
            {
                color: "#616161"
            }
        ]
    },
    {
        featureType: "road.local",
        elementType: "labels.text.fill",
        stylers: [
            {
                color: "#9e9e9e"
            }
        ]
    },
    {
        featureType: "transit.line",
        elementType: "geometry",
        stylers: [
            {
                color: "#e5e5e5"
            }
        ]
    },
    {
        featureType: "transit.station",
        elementType: "geometry",
        stylers: [
            {
                color: "#eeeeee"
            }
        ]
    },
    {
        featureType: "water",
        elementType: "geometry",
        stylers: [
            {
                color: "#c9c9c9"
            }
        ]
    },
    {
        featureType: "water",
        elementType: "labels.text.fill",
        stylers: [
            {
                color: "#9e9e9e"
            }
        ]
    }]
let map, longitude, latitude