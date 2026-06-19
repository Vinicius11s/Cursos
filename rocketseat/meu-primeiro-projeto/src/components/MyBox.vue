<template>
    <div class="box">
        {{ name }} - {{ age }}
        <span :class="['status',status]"> - {{ status }}</span>
    </div>
</template>

<script>
    export default {
        name: 'MyBox',
        props: {
            name: {
                type: String,
                  default: "N/A"
            },
            age: {
                type: Number,
                required : true
            },
            status: {
                type: String,
                validator: value => ['active', 'inactive'].includes(value),
                default: 'active' 
            }
        }
    }
</script>

<style scoped>
.active {
    background-color: green;
}
.inactive {
    background-color: red
}

.box {
    width: 30px;    
    height: 30px;
    background-color: rgb(0, 0, 0);
    align-items: center;
    justify-content: center;
    display: flex;
}
</style>