let watch = {
    model: 'ABC123',      
    color: 'silver',       
    isInStock: true,      
    price: 199.99,  
    toString: function() {
        return `Watch Model: ${this.model}\nColor: ${this.color}\nIn Stock: ${this.isInStock}\nPrice: ${this.price}`;
    },
};

const jsonValue = '{"discount":"20"}';
const discount = JSON.parse(jsonValue)

console.log(discount)

const discountPercentage = parseFloat(discount.discount);

console.log(discountPercentage)

// formatter
const formattedDiscount = (discountPercentage / 100).toLocaleString(undefined, { style: 'percent', minimumFractionDigits: 2 });

console.log(formattedDiscount)